using AutoMapper;
using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.View.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesWorkshop.Domain.Mappings
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderViewModel>();
        }
    }
}
