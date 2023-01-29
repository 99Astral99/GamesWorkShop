using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesWorkshop.Service.Interfaces
{
    public interface ICartService
    {
        Task<IBaseResponse<IEnumerable<OrderViewModel>>> GetItems(string userName);
    }
}
