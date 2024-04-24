using Dto;
using Dto.Request;
using Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IClientesService
    {
        Task<BaseResponseGeneric<ICollection<ClientesResponseDto>>> GetAsync();
        Task<BaseResponseGeneric<ClientesResponseDto>> GetAsync(int id);
        Task<BaseResponseGeneric<int>> AddAsync(ClientesRequestDto request);
        Task<BaseResponse> UpdateAsync(int id, ClientesRequestDto request);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
