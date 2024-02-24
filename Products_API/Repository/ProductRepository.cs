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
            => await _storeContext.Products.Include(p => p.Brand).ToListAsync();
        //=> await _storeContext.Products.ToListAsync();

        public async Task<Product> GetById(int id)
            => await _storeContext.Products.Include(p => p.Brand).FirstAsync(p => p.Id == id);
        //=> await _storeContext.Products.FindAsync(id);

        public async Task Add(Product product)
            => await _storeContext.Products.AddAsync(product);

        public void Update(Product product)
        {
            _storeContext.Products.Attach(product);
            _storeContext.Products.Entry(product).State = EntityState.Modified;
        }

        public void Delete(Product product)
            => _storeContext.Products.Remove(product);

        public async Task Save()
            => await _storeContext.SaveChangesAsync();
    }
}
