using AutoMapper;
using testAPI.Dtos.Product;
using testAPI.Models;

namespace testAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProduceDate, opt => opt.MapFrom(src => src.ProduceDate))
                .ForMember(dest => dest.ManufacturePhone, opt => opt.MapFrom(src => src.ManufacturePhone))
                .ForMember(dest => dest.ManufactureEmail, opt => opt.MapFrom(src => src.ManufactureEmail))
                .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.IsAvailable));

            CreateMap<CreateProductDto, Product>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProduceDate, opt => opt.MapFrom(src => src.ProduceDate))
                .ForMember(dest => dest.ManufacturePhone, opt => opt.MapFrom(src => src.ManufacturePhone))
                .ForMember(dest => dest.ManufactureEmail, opt => opt.MapFrom(src => src.ManufactureEmail))
                .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.IsAvailable));

            CreateMap<UpdateProductDto, Product>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProduceDate, opt => opt.MapFrom(src => src.ProduceDate))
                .ForMember(dest => dest.ManufacturePhone, opt => opt.MapFrom(src => src.ManufacturePhone))
                .ForMember(dest => dest.ManufactureEmail, opt => opt.MapFrom(src => src.ManufactureEmail))
                .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.IsAvailable));
        }
    }
}
