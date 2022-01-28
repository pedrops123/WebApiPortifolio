
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portifolio.Domain.Query.Configurations
{
    public abstract class DapperCustomSearch<T, F> where T : class
    {
        private IConfigurationRoot _conf;
        protected string _connectionStrings
        {
            get
            {
                return _conf.GetConnectionString("DefaultConnection");
            }
        }

        public DapperCustomSearch()
        {
            _conf = ConfigurationRootFactory.SetConfigurationRootBuilder();
        }


        public virtual async Task<T> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task<List<T>> GetList(F filter)
        {
            throw new System.NotImplementedException();
        }
    }
}
