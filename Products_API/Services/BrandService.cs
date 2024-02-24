using Products_API.DTOs;
using Products_API.Model;
using Products_API.Repository;

namespace Products_API.Services
{
    public class BrandService : ICommonService<BrandDto>
    {
        private IRepository<Brand> _brandRepository;
        public BrandService([FromKeyedServices("brandRepository")]IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task Add(BrandDto brandDto)
        {
            Brand brand = new Brand{ Name = brandDto.Name };
            await _brandRepository.Add(brand);
            await _brandRepository.Save();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BrandDto>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<BrandDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, BrandDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
