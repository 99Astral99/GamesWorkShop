using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesWorshop.DAL.Interfaces
{
    public interface IProductRepository:IBaseRepository<Product>
    {
        Task<Product> GetByName(string name);
        Task <IEnumerable<Product>> GetProductsByCategory(int category);
    }
}
