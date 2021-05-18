using AutoMapper;
using Rest.Api.Dtos;
using Rest.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Api.Helpers.AutoMapper
{
    public class MapProfile : Profile
    {

        public MapProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductUpdateDto>();
            CreateMap<ProductDetailsDto, Product>()
                .ForMember(member1 => member1.Name, member2 => member2.MapFrom(x => x.Name))
                .ForMember(member1 => member1.Amount, member2 => member2.MapFrom(x => x.Amount))
                .ForMember(member1 => member1.Quantity, member2 => member2.MapFrom(x => x.Quantity))
                .ForMember(member1 => member1.Category, member2 => member2.MapFrom(x => x.Category));
            CreateMap<Product, ProductDetailsDto>()
                .ForMember(member1 => member1.Name, member2 => member2.MapFrom(x => x.Name))
                .ForMember(member1 => member1.Amount, member2 => member2.MapFrom(x => x.Amount))
                .ForMember(member1 => member1.Quantity, member2 => member2.MapFrom(x => x.Quantity))
                .ForMember(member1 => member1.Category, member2 => member2.MapFrom(x => x.Category));

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<CategoryDto, CategoryUpdateDto>();
            CreateMap<Category, CategoryDetailDto>();
            CreateMap<CategoryDetailDto, Category>();
        }
    }
}
