using Dto.Request;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Dto.Response;

namespace Services.Interface
{
    public interface IPedidosService
    {
        Task<BaseResponse> AddPedido(PedidosRequestDto pedidos);
        Task<List<PedidosResponseDto>> FindPedido(string DNI);
    }
}
