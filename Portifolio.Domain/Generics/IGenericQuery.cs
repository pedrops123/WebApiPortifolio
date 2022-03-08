using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portifolio.Domain.Generics
{
    public interface IGenericQuery<T, F> 
    {
        public Task<T> GetById(int id);

        public Task<List<T>> GetList(F filter);
    }
}
