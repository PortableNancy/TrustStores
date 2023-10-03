using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustStores.Core.DTOs;

namespace TrustStores.Core.Model
{
    public class MapInitializer : Profile
    {
        public MapInitializer()
        {
             CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
