using Products_API.DTOs;

namespace Products_API.Services
{
    public interface ICommonService<DTO>
    {
        Task<IEnumerable<DTO>> Get();
        Task<DTO> GetById(int id);
        Task Add(DTO dto);
        Task Update(int id, DTO dto);
        Task Delete(int id);
    }
}
