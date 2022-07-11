using MediatR;
using Microsoft.AspNetCore.Mvc;
using mytest.Application.Commands.CreateVenda;
using mytest.Application.Models.Input;
using mytest.Application.Queries.GetVendaById;
using mytest.Infra.CloudServices.Interfaces;
using System.Threading.Tasks;

namespace mytest.API.Controllers
{
    [Route("api/venda")]
    public class VendaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEmailServices _emailServices;
        public VendaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateVendaCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetVendaByIdQuery(id);

            var produto = await _mediator.Send(query);

            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

    }
}
