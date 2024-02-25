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
        private ICommonService<BrandDto, BrandDto> _brandService;
        public BrandController([FromKeyedServices("brandService")]ICommonService<BrandDto, BrandDto> brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(BrandDto brandDto)
        {
            await _brandService.Add(brandDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update (int id, BrandDto brandDto)
        {
            if (await _brandService.Update(id, brandDto))
                return Ok();
            return NotFound();
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _brandService.Delete(id))
                return Ok();
            return NotFound();
        }
    }
}
