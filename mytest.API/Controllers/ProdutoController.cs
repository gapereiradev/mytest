using MediatR;
using Microsoft.AspNetCore.Mvc;
using mytest.Application.Commands.CreatePessoa;
using mytest.Application.Commands.CreateProduto;
using mytest.Application.Queries.GetAllProdutos;
using mytest.Application.Queries.GetProdutoById;
using System.Threading.Tasks;

namespace mytest.API.Controllers
{
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProdutoCommand command)
        {

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProdutoByIdQuery(id);

            var produto = await _mediator.Send(query);

            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProdutosQuery();

            var produtos = await _mediator.Send(query);

            if (produtos == null)
            {
                return NotFound();
            }
            return Ok(produtos);
        }

    }
}
