using Dto;
using Dto.Request;
using Dto.Response;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IPedidosRepository
    {
        Task<BaseResponse> AddPedido(PedidosRequestDto pedidos);
        Task<List<PedidosResponseDto>> FindPedido(string DNI);
    }
}
