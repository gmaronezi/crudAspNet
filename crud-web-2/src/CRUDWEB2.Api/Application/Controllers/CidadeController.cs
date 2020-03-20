using System;
using CRUDWEB2.Api.Domain.Cidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPMigracao.Api.Domain.Cidades;

namespace CRUDWEB2.Api.Application.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/v1/cidades")]
    public class CidadeController : ControllerBase
    {
        public ICidadeService _cidadeService { get; }
        public CidadeController(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }


        [HttpGet()]
        public IActionResult FindAll()
        {
            var result = _cidadeService.FindAll();

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public IActionResult FindOne([FromRoute] Guid id)
        {
            var result = _cidadeService.FindOne(id);

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] Cidade body)
        {
            body.Id = id;

            var result = _cidadeService.Update(body);

            if (!result.Completed)
            {
                return BadRequest(result);
            }

            return Ok(result.Result);
        }

        [HttpPost()]
        public IActionResult New([FromBody] Cidade body)
        {
            var result = _cidadeService.Insert(body);

            if (!result.Completed)
            {
                return BadRequest(result);
            }

            return Ok(result.Result);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var result = _cidadeService.Remove(id);

            if (!result.Completed)
            {
                return BadRequest(result);
            }

            return Ok();
        }
    }
}