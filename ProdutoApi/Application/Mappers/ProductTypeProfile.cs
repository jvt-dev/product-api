using AutoMapper;
using ProdutoApi.Application.UseCases.Commands;
using ProdutoApi.Domain.Entities;

namespace ProdutoApi.Application.Mappers
{
    public class ProductTypeProfile : Profile
    {
        public ProductTypeProfile()
        {
            CreateMap<CreateProductTypeCommand, ProductTypeEntity>()
                .ForMember(dest => dest.TaxId, opt => opt.MapFrom(src => src.TaxId))
                .ForMember(dest => dest.MeasurementsId, opt => opt.MapFrom(src => src.MeasurementsId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.MeasurementValue, opt => opt.MapFrom(src => src.MeasurementValue));
        }
    }
}
