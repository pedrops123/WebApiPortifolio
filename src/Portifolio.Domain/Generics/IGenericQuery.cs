using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portifolio.Domain.Generics
{
    public interface IGenericQuery<T, F>
        where T : class
        where F : class
    {
        Task<T> GetById(int id);
        Task<List<T>> GetList(F filter);
    }
}