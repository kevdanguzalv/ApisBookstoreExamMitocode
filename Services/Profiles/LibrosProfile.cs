using AutoMapper;
using Dto.Request;
using Dto.Response;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Profiles
{
    public class LibrosProfile : Profile
    {
        public LibrosProfile()
        {

            CreateMap<Libros, LibrosResponseDto>();
            CreateMap<LibrosRequestDto, Libros>();
        }
    }
}
