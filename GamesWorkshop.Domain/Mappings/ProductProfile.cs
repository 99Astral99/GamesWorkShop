using AutoMapper;
using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.View.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesWorkshop.Domain.Mappings
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDetailsViewModel>()
                .ForMember(c => c.Category, opt => opt.MapFrom(c => c.Category.ToString()));

            CreateMap<Product, ProductViewModel>()
                .ForMember(c => c.Category, opt => opt.MapFrom(c=>c.Category.ToString()));
        }
    }
}
