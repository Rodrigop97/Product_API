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

        public async Task<Product> GetById(int id)
            => await _storeContext.Products.FirstAsync(x => x.Id == id);

        public async Task Add(Product product)
            => await _storeContext.Products.AddAsync(product);

        public void Update(Product product)
        {
            _storeContext.Products.Attach(product);
            _storeContext.Products.Entry(product).State = EntityState.Modified;
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task Save()
            => await _storeContext.SaveChangesAsync();
    }
}
