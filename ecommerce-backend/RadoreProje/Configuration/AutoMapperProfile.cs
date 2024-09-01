using AutoMapper;
using RadoreProje.Models;
using RadoreProje.Dto;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Rating, RatingDto>()
            .ReverseMap();
        CreateMap<Product, ProductDto>()
            .ReverseMap();
        CreateMap<ColorOption, ColorOptionDto>()
            .ReverseMap();
    }
}