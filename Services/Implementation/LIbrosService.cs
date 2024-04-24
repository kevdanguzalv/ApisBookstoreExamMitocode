using AutoMapper;
using Dto;
using Dto.Request;
using Dto.Response;
using Entities;
using Microsoft.Extensions.Logging;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class LibrosService: ILibrosService
    {

        private readonly ILibrosRepository repository;
        private readonly ILogger<LibrosService> logger;
        private readonly IMapper mapper;
        public LibrosService(ILibrosRepository repository, ILogger<LibrosService> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<BaseResponseGeneric<ICollection<LibrosResponseDto>>> GetAsync()
        {
            var response = new BaseResponseGeneric<ICollection<LibrosResponseDto>>();
            try
            {
                response.Data = mapper.Map<ICollection<LibrosResponseDto>>(await repository.GetAsync());
                response.Success = response.Data != null;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener la información.";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseGeneric<LibrosResponseDto>> GetAsync(int id)
        {
            var response = new BaseResponseGeneric<LibrosResponseDto>();
            try
            {
                response.Data = mapper.Map<LibrosResponseDto>(await repository.GetAsync(id));
                response.Success = response.Data != null;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener la información.";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        public async Task<BaseResponseGeneric<int>> AddAsync(LibrosRequestDto request)
        {
            var response = new BaseResponseGeneric<int>();
            try
            {
                response.Data = await repository.AddAsync(mapper.Map<Libros>(request));
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al añadir la informacion.";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        public async Task<BaseResponse> UpdateAsync(int id, LibrosRequestDto request)
        {
            var response = new BaseResponse();
            try
            {
                var entity = await repository.GetAsync(id);
                if (entity is null)
                {
                    response.ErrorMessage = "No se encontró el registro";
                    return response;
                }

                mapper.Map(request, entity);
                await repository.UpdateAsync();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al actualizar la información.";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var response = new BaseResponse();
            try
            {
                await repository.DeleteAsync(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al eliminar la información.";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
    }
}
