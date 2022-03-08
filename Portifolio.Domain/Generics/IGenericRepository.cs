using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portifolio.Domain.Generics
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> Add(T objeto);
        public Task Delete(T objeto);
        public Task Update(T objeto);
        public Task<T> GetEntityById(int id);
        public Task<List<T>> List();
    }
}
