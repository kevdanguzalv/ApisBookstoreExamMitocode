using Dto.Response;
using Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto.Request;

namespace Services.Profiles
{
    public class ClientesProfile : Profile
    {
        public ClientesProfile()
        {
           
            CreateMap<Clientes, ClientesResponseDto>();
            CreateMap<ClientesRequestDto, Clientes>();
        }
    }
}
