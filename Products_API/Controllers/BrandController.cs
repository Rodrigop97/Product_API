using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products_API.DTOs;
using Products_API.Services;

namespace Products_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private ICommonService<BrandDto> _brandService;
        public BrandController([FromKeyedServices("brandService")]ICommonService<BrandDto> brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(BrandDto brandDto)
        {
            await _brandService.Add(brandDto);
            return Ok();
        }
    }
}
