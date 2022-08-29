
using Application.Models.Asset;
using Application.Services.AssetService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssetController( IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpGet("GetAllAssets")]
        [Authorize]
        public IActionResult GetAllAssets([FromQuery] bool enableCache)
        {
            var result = _assetService.GetAll(enableCache);
            return Ok(result);
        }
        [HttpGet("GetAllAssetsByPage")]
        [Authorize]
        public IActionResult GetAllAssetsByPage([FromQuery] int pageNumber, int pageSize, bool enableCache)
        {
            var result = _assetService.GetAllByPage(pageNumber, pageSize,enableCache );
            return Ok(result);
        }
        [HttpGet("GetAssetById")]
        [Authorize]
        public IActionResult GetAssetById([FromQuery] long id)
        {
            var result = _assetService.GetById(id);
            return Ok(result);
        }

        [HttpPost("CreateAsset")]
        [Authorize]
        public IActionResult CreateAsset([FromBody] AddAssetPayload request)
        {
            _assetService.Create(request, getCurrentUser());
            return StatusCode(201);
        }

        [HttpPost("UpdateAsset")]
        [Authorize]
        public IActionResult UpdateAsset([FromBody] UpdateAssetPayload request)
        {
            _assetService.Update(request, getCurrentUser());
            return StatusCode(201);
        }

        [HttpDelete("DeleteAsset")]
        [Authorize]
        public IActionResult DeleteAsset([FromQuery] long Id)
        {
            var result = _assetService.Delete(Id, getCurrentUser());
            return Ok(result);
        }
        private string? getCurrentUser()
        {
            if (HttpContext.User.Claims.Any())
                return HttpContext.User.Claims.First().Value;
            return null;
        }
    }
}
