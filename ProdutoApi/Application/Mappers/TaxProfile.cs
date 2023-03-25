using AutoMapper;
using ProdutoApi.Application.UseCases.Commands;
using ProdutoApi.Domain.Entities;

namespace ProdutoApi.Application.Mappers
{
    public class TaxProfile : Profile
    {
        public TaxProfile() 
        {
            CreateMap<CreateTaxCommand, TaxEntity>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ReverseMap();
        }
    }
}
