using MediatR;
using mytest.Application.Models.ViewModel;
using mytest.Core.Entities;
using mytest.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mytest.Application.Queries.GetProdutoById
{
    public class GetProdutoByIdQueryHandler : IRequestHandler<GetProdutoByIdQuery, ProdutoViewModel>
    {
        private readonly IProdutoRepository _produtoRepository;
        public GetProdutoByIdQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<ProdutoViewModel> Handle(GetProdutoByIdQuery request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByIdAsync(request.Id);

            if (produto == null)
                return null;

            return new ProdutoViewModel(produto.Id, produto.Nome, produto.Valor, produto.QuantidadeEmEstoque);
        }
    }
}
