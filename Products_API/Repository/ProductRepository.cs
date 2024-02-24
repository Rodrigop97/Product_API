using Microsoft.EntityFrameworkCore;
using Products_API.DTOs;
using Products_API.Model;

namespace Products_API.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private StoreContext _storeContext;
        public ProductRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<IEnumerable<Product>> Get()
            => await _storeContext.Products.ToListAsync();

    }
}
