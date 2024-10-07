using AutoMapper;
using Crypto.Base.Models;
using Crypto.Shared.Models.ExchangeRate;

namespace Crypto.Shared.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApiResponse, CryptoQuote>()
                .ForMember(dest => dest.AUD, opt => opt.MapFrom(src => src.Rates != null && src.Rates.Aud != null ? src.Rates.Aud : null))
                .ForMember(dest => dest.GBP, opt => opt.MapFrom(src => src.Rates != null && src.Rates.Gbp != null ? src.Rates.Gbp : null))
                .ForMember(dest => dest.USD, opt => opt.MapFrom(src => src.Rates != null && src.Rates.Usd != null ? src.Rates.Usd : null))
                .ForMember(dest => dest.EUR, opt => opt.MapFrom(src => src.Rates != null && src.Rates.Eur != null ? src.Rates.Eur : null))
                .ForMember(dest => dest.BRL, opt => opt.MapFrom(src => src.Rates != null && src.Rates.Brl != null ? src.Rates.Brl : null))
                ;
        }
    }
}