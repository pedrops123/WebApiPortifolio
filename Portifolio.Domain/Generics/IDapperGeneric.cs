using System.Collections.Generic;


namespace Portifolio.Domain.Generics
{
    public interface IDapperGeneric<T, F> 
    {
        public List<T> GetList(F filter);

        public T GetById(int id);
    }
}
