using AutoMapper;
using LicenseProject.Domain.Models;
using LicenseProject.Infrastructure.DTOs;

namespace LicenseProject.Infrastructure.AutoMappersProfiles
{
    public class LicenseProfile : Profile
    {
        public LicenseProfile()
        {
            CreateMap<Licenses, LicenseDTO>()
                .ForMember(a => a.ProductId, b => b.MapFrom(c => c.Product.Id))
                .ForMember(d => d.ClientId, e => e.MapFrom(f => f.Client.Id));
        }
    }
}
