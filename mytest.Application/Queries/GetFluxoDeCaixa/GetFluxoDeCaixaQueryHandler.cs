using MediatR;
using mytest.Application.Models.ViewModel;
using mytest.Core.DTOs;
using mytest.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mytest.Application.Queries.GetFluxoDeCaixa
{
   public class GetFluxoDeCaixaByPessoaIdQueryHandler : IRequestHandler<GetFluxoDeCaixaByPessoaIdQuery, List<FluxoDeCaixaDTO>>
   {
        private readonly IDapperRepository _dapperRepository;
       public GetFluxoDeCaixaByPessoaIdQueryHandler(IDapperRepository dapperRepository)
       {
            _dapperRepository = dapperRepository;
       }
       public async Task<List<FluxoDeCaixaDTO>> Handle(GetFluxoDeCaixaByPessoaIdQuery request, CancellationToken cancellationToken)
       {
            return await _dapperRepository.GetFluxoDeCaixaByPessoaId(request.PessoaId);
       }
   }
}
