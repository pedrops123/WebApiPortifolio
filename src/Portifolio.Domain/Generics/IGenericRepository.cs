using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portifolio.Domain.Generics
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T objeto);
        Task Delete(T objeto);
        Task Update(T objeto);
        Task<T> GetEntityById(int id);
        Task<List<T>> List();
        Task AddRange(List<T> listObject);
        Task RemoveRange(List<T> listObject);
    }
}