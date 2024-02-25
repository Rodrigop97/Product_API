using Microsoft.VisualBasic;
using Products_API.DTOs;
using Products_API.Model;
using Products_API.Repository;

namespace Products_API.Services
{
    public class BrandService : ICommonService<BrandDto, BrandDto>
    {
        private IRepository<Brand> _brandRepository;
        public BrandService([FromKeyedServices("brandRepository")]IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public Task<IEnumerable<BrandDto>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<BrandDto> GetById(int id)
        {
            Brand brand = await _brandRepository.GetById(id);
            BrandDto brandDto = new BrandDto
            {
                Name = brand.Name
            };
            return brandDto;
        }

        public async Task<bool> Add(BrandDto brandDto)
        {
            try
            {
                Brand brand = new Brand{ Name = brandDto.Name };
                await _brandRepository.Add(brand);
                await _brandRepository.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public async Task<bool> Update(int id, BrandDto brandDto)
        {
            Brand brand = await _brandRepository.GetById(id);
            if (brand != null)
            {
                brand.Name = brandDto.Name;
                _brandRepository.Update(brand);
                await _brandRepository.Save();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            Brand brand = await _brandRepository.GetById(id);
            if (brand != null)
            {
                _brandRepository.Delete(brand);
                await _brandRepository.Save();
                return true;
            }
            return false;
        }

    }
}
