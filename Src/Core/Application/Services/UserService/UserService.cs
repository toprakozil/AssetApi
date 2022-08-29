using Application.Models.DTOs;
using Application.Models.User;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;
        private readonly IDistributedCache _cache;
        public UserService(IUserRepository userRepository, IDistributedCache cache, IConfiguration config)
        {
            _userRepository = userRepository;
            _cache = cache;
            _config = config;
        }

        public bool CanLogin(LoginUserPayload payload)
        {
            var user = _userRepository.GetByUserName(payload.UserName);
            if (user != null && user.DeletedDate == null)
            {
                return Security.PasswordHasher.Verify(payload.Password, user.Password);
            }
            return false;
        }

        public User GetUserByUserName(string userName)
        {
            return _userRepository.GetByUserName(userName);
        }

        public long Register(AddUserPayload addPayload, string? currentUser)
        {
            var existingUser = _userRepository.GetByUserName(addPayload.UserName);
            if (existingUser != null)
            {
                throw new Exception($"Username : {addPayload.UserName} exists.");
            }
            long? current = null;
            if (!string.IsNullOrEmpty(currentUser))
            {
                current = _userRepository.GetByUserName(currentUser).Id;
            }
            var hashpassword = Security.PasswordHasher.Hash(addPayload.Password);
            var user = new User()
            {
                UserName = addPayload.UserName,
                Name = addPayload.Name,
                LastName = addPayload.LastName,
                Email = addPayload.Email,
                DateOfBirth = addPayload.DateOfBirth,
                PhoneNumber = addPayload.PhoneNumber,
                Password = hashpassword,
                CreatedDate = DateTime.Now,
                CreatedUser = current
            };
            _userRepository.Create(user);
            _userRepository.SaveChanges();
            return user.Id;
        }

        public bool Delete(long id, string? currentUser)
        {
            long? current = null;
            if (!string.IsNullOrEmpty(currentUser))
            {
                current = _userRepository.GetByUserName(currentUser).Id;
            }
            var user = _userRepository.Get(id);
            if (user != null)
            {
                user.DeletedUser = current;
                user.DeletedDate = DateTime.Now;
                _userRepository.Update(user);
                _userRepository.SaveChanges();

            }
            else
            {
                throw new Exception($"User with id: {id} does not active/exist.");
            }
            return true;
        }

        public List<UserDto> GetUsersByCount(int count, bool enableCache)
        {
            if (!enableCache)
            {
                return _userRepository.GetQueryable().OrderByDescending(u => u.CreatedDate).Take(count).Select(o =>
                    new UserDto
                    {
                        Id = o.Id,
                        UserName = o.UserName,
                        Name = o.Name,
                        LastName = o.LastName,
                        Email = o.Email,
                        DateOfBirth = o.DateOfBirth,
                        PhoneNumber = o.PhoneNumber,
                        CreatedDate = o.CreatedDate,
                        CreatedUser = o.CreatedUser,
                        UpdatedDate = o.UpdatedDate,
                        UpdatedUser = o.UpdatedUser
                    }).ToList();

            }
            else
            {
                string cacheKey = "GetUsersByCount" + count.ToString();
                // Trying to get data from the Redis cache
                byte[] cachedData = _cache.Get(cacheKey);
                List<UserDto> users = new();
                if (cachedData != null)
                {
                    // If the data is found in the cache, encode and deserialize cached data.
                    var cachedDataString = Encoding.UTF8.GetString(cachedData);
                    return users = JsonSerializer.Deserialize<List<UserDto>>(cachedDataString);
                }
                else
                {
                    // If the data is not found in the cache, then fetch data from database
                    users = _userRepository.GetQueryable().OrderByDescending(u => u.CreatedDate).Take(count).Select(o =>
                    new UserDto
                    {
                        Id = o.Id,
                        UserName = o.UserName,
                        Name = o.Name,
                        LastName = o.LastName,
                        Email = o.Email,
                        DateOfBirth = o.DateOfBirth,
                        PhoneNumber = o.PhoneNumber,
                        CreatedDate = o.CreatedDate,
                        CreatedUser = o.CreatedUser,
                        UpdatedDate = o.UpdatedDate,
                        UpdatedUser = o.UpdatedUser
                    }).ToList();

                    // Serializing the data
                    string cachedDataString = JsonSerializer.Serialize(users);
                    var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);

                    // Setting up the cache options 
                    var abs = _config["redisOptions:absoluteInMinutes"];
                    var sliding = _config["redisOptions:slidingInMinutes"];
                    DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(Convert.ToInt32(abs)))
                        .SetSlidingExpiration(TimeSpan.FromMinutes(Convert.ToInt32(sliding)));

                    // Add the data into the cache
                    _cache.Set(cacheKey, dataToCache, options);
                    return users;
                }
            }

        }

    }
}
