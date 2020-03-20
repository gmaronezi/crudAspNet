using CRUDWEB2.Api.Domain.Cidades;
using SPMigracao.Api.Domain.Cidades;
using SPMigracao.Api.Infrastructure.Context;
using SPMigracao.Api.Infrastructure.Repositories;

namespace CRUDWEB2.Api.Infrastructure.Repositories
{
    public class CidadeRepository : AbstractRepository<Cidade>, ICidadeRepository
    {
         public CidadeRepository(MainContext context) : base(context)
        {

        }
    }
}