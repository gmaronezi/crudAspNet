using CRUDWEB2.Api.Domain.Clientes;
using SPMigracao.Api.Infrastructure.Context;
using SPMigracao.Api.Infrastructure.Repositories;

namespace CRUDWEB2.Api.Infrastructure.Repositories
{
    public class ClienteRepository : AbstractRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(MainContext context) : base(context)
        {

        }
    }
}