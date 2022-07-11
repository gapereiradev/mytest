using MediatR;
using mytest.Application.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Application.Queries.GetAllPessoas
{
    public class GetAllPessoasQuery : IRequest<List<PessoaViewModel>>
    {
    }
}
