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

namespace mytest.Application.Queries.GetAllProdutos
{
    public class GetAllProdutosQueryHandler : IRequestHandler<GetAllProdutosQuery, List<ProdutoViewModel>>
    {
        private readonly IProdutoRepository _produtoRepository;
        public GetAllProdutosQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<List<ProdutoViewModel>> Handle(GetAllProdutosQuery request, CancellationToken cancellationToken)
        {
            var produtos = await _produtoRepository.GetAllAsync();

            if (produtos == null)
                return null;

            List<ProdutoViewModel> produtosViewModel = new List<ProdutoViewModel>();
            foreach (Produto produto in produtos)
            {
                produtosViewModel.Add(new ProdutoViewModel(produto.Id, produto.Nome, produto.Valor, produto.QuantidadeEmEstoque));
            }

            return produtosViewModel;
        }
    }
}
