﻿using Products_API.DTOs;

namespace Products_API.Services
{
    public interface ICommonService<DTO>
    {
        Task<IEnumerable<DTO>> Get();
    }
}