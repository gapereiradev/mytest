using MediatR;
using mytest.Application.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Application.Queries.GetAllProdutos
{
    public class GetAllProdutosQuery : IRequest<List<ProdutoViewModel>>
    {

    }
}
