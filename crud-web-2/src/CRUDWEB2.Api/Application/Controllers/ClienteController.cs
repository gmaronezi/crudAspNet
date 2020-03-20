using System;
using CRUDWEB2.Api.Domain.Clientes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWEB2.Api.Application.Controllers
{
  [ApiController]
    [AllowAnonymous]
    [Route("api/v1/clientes")]
    public class ClienteController : ControllerBase
    {
        public IClienteService _clienteService { get; }
        public ClienteController(IClienteService originService)
        {
            _clienteService = originService;
        }


        [HttpGet()]
        public IActionResult FindAll()
        {
            var result = _clienteService.FindAll();

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public IActionResult FindOne([FromRoute] Guid id)
        {
            var result = _clienteService.FindOne(id);

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] Cliente body)
        {
            body.Id = id;

            var result = _clienteService.Update(body);

            if (!result.Completed)
            {
                return BadRequest(result);
            }

            return Ok(result.Result);
        }

        [HttpPost()]
        public IActionResult New([FromBody] Cliente body)
        {
            var result = _clienteService.Insert(body);

            if (!result.Completed)
            {
                return BadRequest(result);
            }

            return Ok(result.Result);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var result = _clienteService.Remove(id);

            if (!result.Completed)
            {
                return BadRequest(result);
            }

            return Ok();
        }
    }
}