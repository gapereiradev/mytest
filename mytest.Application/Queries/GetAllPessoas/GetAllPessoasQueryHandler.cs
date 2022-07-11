using MediatR;
using mytest.Application.Models.View;
using mytest.Core.Entities;
using mytest.Core.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace mytest.Application.Queries.GetAllPessoas
{
    public class GetAllPessoasQueryHandler : IRequestHandler<GetAllPessoasQuery, List<PessoaViewModel>>
    {
        private readonly IPessoaRepository _pessoaRepository;

        public GetAllPessoasQueryHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<List<PessoaViewModel>> Handle(GetAllPessoasQuery request, CancellationToken cancellationToken)
        {
            var pessoas = await _pessoaRepository.GetAllAsync();

            if (pessoas == null)
                return null;

            List<PessoaViewModel> pessoasViewModel = new List<PessoaViewModel>();
            foreach(Pessoa pessoa in pessoas)
            {
                pessoasViewModel.Add(new PessoaViewModel(pessoa.Id, pessoa.Nome, pessoa.CpfCnpj, pessoa.Email, pessoa.Telefone));
            }

            return pessoasViewModel;
        }
    }
}
