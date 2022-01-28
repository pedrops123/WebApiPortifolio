using Dapper;
using Portifolio.Domain.Query.Configurations;
using Portifolio.Domain.Query.Queries.Works.Filters;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Portifolio.Domain.Query.Queries.Works
{
    public sealed class WorksQuery : DapperCustomSearch<Entities.Works,FilterWorksRequest>
    {
        public override async Task<Entities.Works> GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionStrings)){

                SqlBuilder builder = new SqlBuilder();

                builder.Where("Id = @id", new { id = id });

                var queryResult =  builder.AddTemplate("SELECT * FROM Works /**where**/");

                var result = (await connection.QueryAsync<Entities.Works>(queryResult.RawSql, queryResult.Parameters)).FirstOrDefault();

                return result;
            }
        }
    }
}
