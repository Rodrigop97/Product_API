using Microsoft.AspNetCore.Http.HttpResults;
using Products_API.DTOs;
using Products_API.Model;
using Products_API.Repository;

namespace Products_API.Services
{
    public class ProductService : ICommonService<ProductDto>
    {
        private IRepository<Product> _repository;
        public ProductService([FromKeyedServices("productRepository")]IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task Add(ProductDto productDto)
        {
            Product product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                BrandId = productDto.BrandId
            };
            await _repository.Add(product);
            await _repository.Save();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> Get()
        {
            var products = await _repository.Get();
            return products.Select(p => new ProductDto
            {
                Name = p.Name,
                Price = p.Price,
                BrandId = p.BrandId
            });
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await _repository.GetById(id);
            return new ProductDto
            {
                Name = product.Name,
                Price = product.Price,
                BrandId = product.BrandId
            };
        }

        public async Task Update(int id, ProductDto productDto)
        {
            Product product = await _repository.GetById(id);
            if (product == null)
                throw new ArgumentNullException();
            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.BrandId = productDto.BrandId;
            _repository.Update(product);
            await _repository.Save();
        }
    }
}
