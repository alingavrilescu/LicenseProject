using AutoMapper;
using LicenseProject.Domain.Models;
using LicenseProject.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseProject.Infrastructure.AutoMappersProfiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDTO>();
        }
    }
}
