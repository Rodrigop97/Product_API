﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Products_API.DTOs;
using Products_API.Services;

namespace Products_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ICommonService<ProductDto, ProductEditDto> _productService;
        public ProductController(
            [FromKeyedServices("productService")]ICommonService<ProductDto, ProductEditDto> productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get()
            => await _productService.Get();
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = await _productService.GetById(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductEditDto productEditDto)
        {
            if (await _productService.Add(productEditDto))
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductEditDto productEditDto)
        {
            if (await _productService.Update(id, productEditDto))
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _productService.Delete(id))
                return Ok();
            return BadRequest();
        }
    }
}
