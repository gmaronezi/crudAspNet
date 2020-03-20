using System;
using System.Collections.Generic;
using SPMigracao.Api.Application.ViewModels;

namespace CRUDWEB2.Api.Domain.Clientes
{
    public interface IClienteService
    {
         ActionResult<Cliente> Insert(Cliente source);
        ActionResult<Cliente> Update(Cliente source);
        ActionResult Remove(Guid id);
        IEnumerable<Cliente> FindAll();
        Cliente FindOne(Guid id);
        bool Exists(Guid id);
    }
}