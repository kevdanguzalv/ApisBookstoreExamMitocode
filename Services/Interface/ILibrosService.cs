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
    public interface ILibrosService
    {
        Task<BaseResponseGeneric<ICollection<LibrosResponseDto>>> GetAsync();
        Task<BaseResponseGeneric<LibrosResponseDto>> GetAsync(int id);
        Task<BaseResponseGeneric<int>> AddAsync(LibrosRequestDto request);
        Task<BaseResponse> UpdateAsync(int id, LibrosRequestDto request);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
