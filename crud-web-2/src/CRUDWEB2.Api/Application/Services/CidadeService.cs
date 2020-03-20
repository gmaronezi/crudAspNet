using System;
using System.Collections.Generic;
using SPMigracao.Api.Application.ViewModels;
using System.Linq;
using CRUDWEB2.Api.Domain.Cidades;
using SPMigracao.Api.Domain.Cidades;

namespace CRUDWEB2.Api.Application.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeService(ICidadeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }
        public ActionResult Remove(Guid id)
        {
            // Validações pré exclusão
            try
            {
                _cidadeRepository.Delete(id);

                _cidadeRepository.Commit();

                return new ActionResult();
            }
            catch (Exception e)
            {
                return new ActionResult(e.Message);
            }
        }

        public IEnumerable<Cidade> FindAll()
        {
            return _cidadeRepository.Query();
        }

        public Cidade FindOne(Guid id)
        {
            return _cidadeRepository.FindById(id);
        }

        public bool Exists(Guid id)
        {
            return _cidadeRepository.Query().Any(x => x.Id == id);
        }

        public ActionResult<Cidade> Insert(Cidade source)
        {
            try
            {
                source.Id = Guid.NewGuid();

                _cidadeRepository.Add(source);

                _cidadeRepository.Commit();

                return new ActionResult<Cidade>(source);
            }
            catch (Exception e)
            {
                return new ActionResult<Cidade>(e.Message);
            }
        }

        public ActionResult<Cidade> Update(Cidade source)
        {
            try
            {
                if (!_cidadeRepository.Query().Any(x => x.Id == source.Id))
                {
                    return new ActionResult<Cidade>("Registro não encontrado");
                }

                _cidadeRepository.Update(source);

                _cidadeRepository.Commit();

                return new ActionResult<Cidade>(source);
            }
            catch (Exception e)
            {
                return new ActionResult<Cidade>(e.Message);
            }
        }
    }
}