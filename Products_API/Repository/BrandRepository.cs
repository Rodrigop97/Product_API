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
        public async Task Add(Brand brand)
            => await _storeContext.Brands.AddAsync(brand);

        public void Delete(Brand brand)
        {
            throw new NotImplementedException();
        }


        public Task<Brand> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Save()
            => await _storeContext.SaveChangesAsync();

        public void Update(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
