using AutoMapper;
using LicenseProject.Domain.Models;
using LicenseProject.Infrastructure.DTOs;

namespace LicenseProject.Infrastructure.AutoMappersProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>();
        }
    }
}
