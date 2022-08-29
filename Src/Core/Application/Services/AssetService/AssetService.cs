using Application.Models.Asset;
using Application.Models.DTOs;
using Application.Services.UserService;
using Domain.Asset;
using Domain.User;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AssetService
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IUserService _userService;
        public AssetService(IAssetRepository assetRepository, IUserService userService)
        {
            _assetRepository = assetRepository;
            _userService = userService;
        }

        public long Create(AddAssetPayload payload, string? currentUser)
        {
            var asset = new Asset()
            {
                Name = payload.Name,
                MacAddress = payload.MacAddress,
                CategoryId = payload.CategoryId,
                StatusId = 1,
                CreatedDate = DateTime.Now,
                CreatedUser = _userService.GetUserByUserName(currentUser).Id
            };
            _assetRepository.Create(asset);
            _assetRepository.SaveChanges();
            return asset.Id;
        }

        public bool Delete(long id, string? currentUser)
        {
            long? current = null;
            if (!string.IsNullOrEmpty(currentUser))
            {
                current = _userService.GetUserByUserName(currentUser).Id;
            }
            var asset = _assetRepository.Get(id);
            if (asset != null)
            {
                asset.DeletedUser = current;
                asset.DeletedDate = DateTime.Now;
                _assetRepository.Update(asset);
                _assetRepository.SaveChanges();

            }
            else
            {
                throw new Exception($"Asset with id: {id} does not active/exist.");
            }
            return true;
        }

        public  List<AssetDto> GetAll(bool enableCache)
        {
            return _assetRepository.GetQueryable().OrderByDescending(u => u.CreatedDate).AsEnumerable().Select(o => new AssetDto
            {
                Id = o.Id,
                Name = o.Name,
                MacAddress = o.MacAddress,
                CategoryId = o.CategoryId,
                Status = Enum.GetName(typeof(AssetStatus), o.StatusId),
                CreatedDate = o.CreatedDate,
                CreatedUser = o.CreatedUser,
                UpdatedDate = o.UpdatedDate,
                UpdatedUser = o.UpdatedUser
            }).ToList();

        }

        public List<AssetDto> GetAllByPage(int pageNumber, int pageSize, bool enableCache)
        {
            return _assetRepository.GetQueryable().OrderByDescending(u => u.CreatedDate).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsEnumerable().Select(o => new AssetDto
            {
                Id = o.Id,
                Name = o.Name,
                MacAddress = o.MacAddress,
                CategoryId = o.CategoryId,
                Status = Enum.GetName(typeof(AssetStatus), o.StatusId),
                CreatedDate = o.CreatedDate,
                CreatedUser = o.CreatedUser,
                UpdatedDate = o.UpdatedDate,
                UpdatedUser = o.UpdatedUser
            }).ToList();
        }

        public AssetDto GetById(long id)
        {
            var asset = _assetRepository.Get(id);
            if(asset == null)
            {
                throw new Exception($"Asset with id: {id} does not active/exist.");
            }
            return new AssetDto
            {
                Id = asset.Id,
                Name = asset.Name,
                MacAddress = asset.MacAddress,
                CategoryId = asset.CategoryId,
                Status = Enum.GetName(typeof(AssetStatus), asset.StatusId),
                CreatedDate = asset.CreatedDate,
                CreatedUser = asset.CreatedUser,
                UpdatedDate = asset.UpdatedDate,
                UpdatedUser = asset.UpdatedUser

            };

        }

        public long Update(UpdateAssetPayload payload, string? currentUser)
        {
            long? current = null;
            if (!string.IsNullOrEmpty(currentUser))
            {
                current = _userService.GetUserByUserName(currentUser).Id;
            }
            var asset = _assetRepository.Get(payload.Id);
            if (asset != null)
            {
                if (!string.IsNullOrEmpty(payload.Name))
                {
                    asset.Name = payload.Name;
                }
                if(payload.StatusId != null)
                {
                    asset.StatusId = payload.StatusId.Value;
                }
                if (!string.IsNullOrEmpty(payload.MacAddress))
                {
                    var existingMacAdress = _assetRepository.GetQueryable().Where(s => s.MacAddress == payload.MacAddress).FirstOrDefault();
                    if(existingMacAdress == null)
                    {
                        asset.MacAddress = payload.MacAddress;
                    }
                    else
                    {
                        throw new Exception($"Asset with Mac Address: {payload.MacAddress} already exists.");
                    }
                }
                asset.UpdatedUser = current;
                asset.UpdatedDate = DateTime.Now;
                _assetRepository.Update(asset);
                _assetRepository.SaveChanges();

            }
            else
            {
                throw new Exception($"Asset with id: {payload.Id} does not active/exist.");
            }
            return asset.Id;
        }
    }
}
