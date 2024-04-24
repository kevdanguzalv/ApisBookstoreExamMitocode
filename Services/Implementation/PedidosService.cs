using AutoMapper;
using Dto.Response;
using Dto;
using Microsoft.Extensions.Logging;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto.Request;
using Services.Interface;
using Entities;

namespace Services.Implementation
{
    public  class PedidosService: IPedidosService
    {
        private readonly IPedidosRepository repository;
        private readonly ILogger<PedidosService> logger;
        public PedidosService(IPedidosRepository repository, ILogger<PedidosService> logger) 
        {
             this.repository = repository;
            this.logger = logger;
        }

        public async Task<BaseResponse> AddPedido(PedidosRequestDto pedidos)
        {
            var response = new BaseResponse();
            try
            {
                await repository.AddPedido(pedidos);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener la información.";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<List<PedidosResponseDto>> FindPedido(string DNI)
        {
            var response = new List<PedidosResponseDto>();
            try
            {
                response = await repository.FindPedido(DNI);
               
            }
            catch (Exception ex)
            {
            logger.LogError(ex, "{ErrorMessage} {Message}", ex.Message);
            }

            return response;
        }
    }
}
