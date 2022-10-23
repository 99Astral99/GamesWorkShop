using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesWorkshop.Service.Interfaces
{
    public interface IProductService
    {
        Task<IBaseResponse<IEnumerable<Product>>> GetProducts();
    }
}
