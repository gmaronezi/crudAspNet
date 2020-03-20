using System;
using System.Collections.Generic;
using SPMigracao.Api.Application.ViewModels;
using System.Linq;
using CRUDWEB2.Api.Domain.Clientes;
using CRUDWEB2.Api.Domain.Cidades;

namespace CRUDWEB2.Api.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ICidadeService _cidadeService;

        public ClienteService(
            IClienteRepository clienteRepository,
            ICidadeService cidadeService)
        {
            _clienteRepository = clienteRepository;
            _cidadeService = cidadeService;
        }

        public ActionResult Remove(Guid id)
        {
            // Validações pré exclusão
            try
            {
                _clienteRepository.Delete(id);

                _clienteRepository.Commit();

                return new ActionResult();
            }
            catch (Exception e)
            {
                return new ActionResult(e.Message);
            }
        }

        public IEnumerable<Cliente> FindAll()
        {
            return _clienteRepository.Query();
        }

        public Cliente FindOne(Guid id)
        {
            return _clienteRepository.FindById(id);
        }

        public ActionResult<Cliente> Insert(Cliente source)
        {
            try
            {
                ValidaOrigemId(source);

                source.Id = Guid.NewGuid();

                _clienteRepository.Add(source);

                _clienteRepository.Commit();

                return new ActionResult<Cliente>(source);
            }
            catch (Exception e)
            {
                return new ActionResult<Cliente>(e.Message);
            }
        }

        private void ValidaOrigemId(Cliente source)
        {
            if (!_cidadeService.Exists(source.CidadeId))
            {
                throw new Exception("Origem não encontrada");
            }
        }

        public ActionResult<Cliente> Update(Cliente source)
        {
            try
            {
                ValidaOrigemId(source);

                if (!_clienteRepository.Query().Any(x => x.Id == source.Id))
                {
                    throw new Exception("Registro não encontrado");
                }

                _clienteRepository.Update(source);

                _clienteRepository.Commit();

                return new ActionResult<Cliente>(source);
            }
            catch (Exception e)
            {
                return new ActionResult<Cliente>(e.Message);
            }
        }

        public bool Exists(Guid id)
        {
            return _clienteRepository.Query().Any(x => x.Id == id);
        }
    }
}