using Portifolio.Domain.Query.Configurations;
using Portifolio.Domain.Query.Queries.Works.Filters;

namespace Portifolio.Domain.Query.Queries.Works
{
    public sealed class WorksQuery : DapperCustomSearch<Entities.Works, FilterWorksRequest>
    {
    }
}
