using System;
using System.Collections.Generic;
using SPMigracao.Api.Application.ViewModels;
using SPMigracao.Api.Domain.Cidades;

namespace CRUDWEB2.Api.Domain.Cidades
{
    public interface ICidadeService
    {
          ActionResult<Cidade> Insert(Cidade source);
        ActionResult<Cidade> Update(Cidade source);
        ActionResult Remove(Guid id);
        IEnumerable<Cidade> FindAll();
        Cidade FindOne(Guid id);
        bool Exists(Guid id);
    }
}