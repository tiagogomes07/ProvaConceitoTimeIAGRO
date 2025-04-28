using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Books.Application.DTO;
using Books.Domain.Entities;

namespace Books.Application.Mapping
{
    public class DomainToDTOMappingProfile : Profile
    {

        public DomainToDTOMappingProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Specification, SpecificationDTO>().ReverseMap();
        }

    }
}
