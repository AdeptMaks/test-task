using Api.Data.Entities;
using Api.Domain.Models.DTOs;
using Api.Domain.Models.Entities;
using AutoMapper;

namespace Api.Services.Mapping;

public class UrlMappingProfile : Profile
{
    public UrlMappingProfile()
    {
        CreateMap<URLEntity, URL>();
        CreateMap<URLEntity, URLShortResponse>()
            .ForMember(dest => dest.ShortenedURL, opt => opt.MapFrom(src => src.ShortenedURL))
            .ForMember(dest => dest.OriginalURL, opt => opt.MapFrom(src => src.OriginalURL));
    }
}