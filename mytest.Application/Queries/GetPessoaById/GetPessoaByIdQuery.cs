using MediatR;
using mytest.Application.Models.View;

namespace mytest.Application.Queries.GetPessoaById
{
    public class GetPessoaByIdQuery : IRequest<PessoaViewModel>
    {
        public GetPessoaByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }

    }
}
