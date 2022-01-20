using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portifolio.Infrastructure.Database.Dapper.Querys.Works.Find
{
   public class FindWorksQuery
    {
        private readonly string _connectionStrings;
        public FindWorksQuery(IConfiguration configuration)
        {
            _connectionStrings = configuration.GetConnectionString("DefaultConnection");
        }
    }
}
