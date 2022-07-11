using MediatR;
using Microsoft.AspNetCore.Mvc;
using mytest.Application.Commands.CreatePessoa;
using mytest.Application.Queries.GetAllPessoas;
using mytest.Application.Queries.GetFluxoDeCaixa;
using mytest.Application.Queries.GetPessoaById;
using System.Threading.Tasks;

namespace mytest.API.Controllers
{
    [Route("api/pessoa")]
    public class PessoaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PessoaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatePessoaCommand command)
        {

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetPessoaByIdQuery(id);

            var pessoa = await _mediator.Send(query);

            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllPessoasQuery();

            var pessoas = await _mediator.Send(query);

            if (pessoas == null)
            {
                return NotFound();
            }
            return Ok(pessoas);
        }

       [HttpGet("FluxoCaixa/{pessoaId}")]
       public async Task<IActionResult> GetFluxoDeCaixa(int pessoaId)
       {
           var query = new GetFluxoDeCaixaByPessoaIdQuery(pessoaId);
       
           var fluxoDeCaixa = await _mediator.Send(query);
           if(fluxoDeCaixa == null)        
           {
               return NotFound();
           }
           return Ok(fluxoDeCaixa);
       }
    }
}
