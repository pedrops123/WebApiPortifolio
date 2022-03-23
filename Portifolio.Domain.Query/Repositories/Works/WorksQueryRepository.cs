using Dapper;
using Portifolio.Domain.Query.Configurations;
using Portifolio.Domain.Query.Mappers.Works;
using Portifolio.Domain.Query.Repositories.Works.Filters;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Portifolio.Domain.Query.Repositories.Works
{
    public sealed class WorksQueryRepository : DapperDefaultSearch<Entities.Works, FilterWorksRequest>
    {
        public override async Task<List<Entities.Works>> GetList(FilterWorksRequest filter)
        {
            SqlBuilder builder = new SqlBuilder();

            if (!string.IsNullOrEmpty(filter.texto_projeto))
            {
                builder.OrWhere("[Works].texto_projeto = @texto_projeto", new { filter.texto_projeto });
            }

            if (!string.IsNullOrEmpty(filter.nome_projeto))
            {
                builder.OrWhere("[Works].nome_projeto = @nome_projeto", new { filter.nome_projeto });
            }

            if (!string.IsNullOrEmpty(filter.descritivo_capa))
            {
                builder.OrWhere("[Works].descritivo_capa = @descritivo_capa", new { filter.descritivo_capa });
            }

            var queryResult = builder.AddTemplate(@"SELECT 
													[Works].Id,
													[Works].nome_projeto,
													[Works].descritivo_capa,
													[Works].texto_projeto,
													[Works].UserInsert,
													[Works].InsertDate,
													[Works].UserUpdate,
													[Works].UpdateDate,
													[Works].img_thumbnail_id,
													[GalleryWorks].Id,
													[GalleryWorks].IdProjeto,
													[GalleryWorks].PathFile,
													[GalleryWorks].UserInsert,
													[GalleryWorks].InsertDate,
													[GalleryWorks].UserUpdate,
													[GalleryWorks].UpdateDate
												FROM [Works] 
												LEFT JOIN [GalleryWorks] ON [GalleryWorks].Id = [Works].img_thumbnail_id
												/**where**/");

            using (SqlConnection connection = new SqlConnection(this._connectionStrings))
            {
                var result = (await connection.QueryAsync<Entities.Works, Entities.GalleryWorks, Entities.Works>(queryResult.RawSql,
                    (work, galleryWorks) => new WorksJoinMap(galleryWorks).Map(work), queryResult.Parameters)).ToList();

                return result;
            }
        }

        public override async Task<Entities.Works> GetById(int id)
        {
            SqlBuilder builder = new SqlBuilder();

            builder.OrWhere("[Works].Id = @id", new { id });

            var queryResult = builder.AddTemplate(@"SELECT 
													[Works].Id,
													[Works].nome_projeto,
													[Works].descritivo_capa,
													[Works].texto_projeto,
													[Works].UserInsert,
													[Works].InsertDate,
													[Works].UserUpdate,
													[Works].UpdateDate,
													[Works].img_thumbnail_id,
													[GalleryWorks].Id,
													[GalleryWorks].IdProjeto,
													[GalleryWorks].PathFile,
													[GalleryWorks].UserInsert,
													[GalleryWorks].InsertDate,
													[GalleryWorks].UserUpdate,
													[GalleryWorks].UpdateDate
												FROM [Works] 
												LEFT JOIN [GalleryWorks] ON [GalleryWorks].Id = [Works].img_thumbnail_id
												/**where**/");

            using (SqlConnection connection = new SqlConnection(this._connectionStrings))
            {
                var result = (await connection.QueryAsync<Entities.Works, Entities.GalleryWorks, Entities.Works>(queryResult.RawSql,
                    (work, galleryWorks) => new WorksJoinMap(galleryWorks).Map(work), queryResult.Parameters)).FirstOrDefault();

                return result;
            }
        }
    }
}