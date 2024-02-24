using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products_API.DTOs;
using Products_API.Services;

namespace Products_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ICommonService<ProductDto> _productService;
        public ProductController(
            [FromKeyedServices("productService")]ICommonService<ProductDto> productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get()
            => await _productService.Get();
    }
}
