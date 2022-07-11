using MediatR;
using mytest.Application.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Application.Queries.GetProdutoById
{
    public class GetProdutoByIdQuery : IRequest<ProdutoViewModel>
    {
        public GetProdutoByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }

    }
}
