using MediatR;
using mytest.Application.Models.View;
using mytest.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mytest.Application.Queries.GetPessoaById
{
    public class GetPessoaByIdQueryHandler : IRequestHandler<GetPessoaByIdQuery, PessoaViewModel>
    {
        private readonly IPessoaRepository _pessoaRepository;

        public GetPessoaByIdQueryHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<PessoaViewModel> Handle(GetPessoaByIdQuery request, CancellationToken cancellationToken)
        {
            var pessoa = await _pessoaRepository.GetByIdAsync(request.Id);

            if (pessoa == null) 
                return null;

            var pessoaViewModel = new PessoaViewModel(pessoa.Id, pessoa.Nome, pessoa.CpfCnpj, pessoa.Email, pessoa.Telefone);
            return pessoaViewModel;
        }
    }
}
