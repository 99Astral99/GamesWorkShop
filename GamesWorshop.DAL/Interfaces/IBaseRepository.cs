using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesWorshop.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Create(T entity);
        Task<T> Update(T entity);
        IQueryable<T> GetAll();
        Task Delete(T entity);
    }
}
