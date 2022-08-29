using Application.Models.Asset;
using Application.Models.DTOs;

namespace Application.Services.AssetService
{
    public interface IAssetService
    {
        List<AssetDto> GetAll(bool enableCache);
        AssetDto GetById(long id);
        long Create(AddAssetPayload payload, string? currentUser);
        long Update(UpdateAssetPayload payload, string? currentUser);
        bool Delete(long id, string? currentUser);
        List<AssetDto> GetAllByPage(int pageNumber, int pageSize, bool enableCache);
    }
}
