using AutoMapper;
using Biblioteca.Domain;
using Biblioteca.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infraestructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Autor, AutorDto>()
                .ForMember(dest => dest.IdAutor, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }
    }
}
