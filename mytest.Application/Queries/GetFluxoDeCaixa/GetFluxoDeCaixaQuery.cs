using MediatR;
using mytest.Application.Models.ViewModel;
using mytest.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Application.Queries.GetFluxoDeCaixa
{
    public class GetFluxoDeCaixaByPessoaIdQuery : IRequest<List<FluxoDeCaixaDTO>>
    {
        public GetFluxoDeCaixaByPessoaIdQuery(int pessoaId)
        {
            PessoaId = pessoaId;
        }

        public int PessoaId { get; set; }
    }
}
