using Products_API.DTOs;
using Products_API.Model;
using Products_API.Repository;

namespace Products_API.Services
{
    public class ProductService : ICommonService<ProductDto>
    {
        private IRepository<Product> _repository;
        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
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
    }
}
