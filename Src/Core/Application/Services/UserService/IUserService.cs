using Application.Models.DTOs;
using Application.Models.User;
using Domain.User;

namespace Application.Services.UserService
{
    public interface IUserService
    {
        bool CanLogin(LoginUserPayload loginPayload);      
        User GetUserByUserName(string userName);
        List<UserDto> GetUsersByCount(int count, bool enableCache);
        long Register(AddUserPayload addPayload, string? currentUser);       
        bool Delete(long id, string? currentUser);
    }
}
