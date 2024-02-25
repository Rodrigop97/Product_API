using Products_API.DTOs;

namespace Products_API.Services
{
    public interface ICommonService<DTO, UDTO>
    {
        Task<IEnumerable<DTO>> Get();
        Task<DTO> GetById(int id);
        Task<bool> Add(UDTO dto);
        Task<bool> Update(int id, UDTO dto);
        Task<bool> Delete(int id);
    }
}
