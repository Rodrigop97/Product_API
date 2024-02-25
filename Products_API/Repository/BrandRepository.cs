using Microsoft.EntityFrameworkCore;
using Products_API.Model;

namespace Products_API.Repository
{
    public class BrandRepository : IRepository<Brand>
    {
        private StoreContext _storeContext;
        public BrandRepository(StoreContext storeContext) 
        {
            _storeContext = storeContext;
        }
        public Task<IEnumerable<Brand>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<Brand> GetById(int id)
            => await _storeContext.Brands.FindAsync(id);

        public async Task Add(Brand brand)
            => await _storeContext.Brands.AddAsync(brand);
        
        public void Update(Brand brand)
        {
            _storeContext.Brands.Attach(brand);
            _storeContext.Brands.Entry(brand).State = EntityState.Modified;
        }

        public void Delete(Brand brand)
        {
            _storeContext.Brands.Remove(brand);
        }

        public async Task Save()
            => await _storeContext.SaveChangesAsync();

    }
}
