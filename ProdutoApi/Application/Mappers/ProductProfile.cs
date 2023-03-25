using AutoMapper;
using ProdutoApi.Application.UseCases.Commands;
using ProdutoApi.Domain.Entities;

namespace ProdutoApi.Application.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, ProductEntity>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForPath(dest => dest.ProductType.Id, opt => opt.MapFrom(src => src.ProductTypeId));
        }
    }
}
