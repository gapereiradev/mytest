using MediatR;
using mytest.Core.Entities;
using mytest.Core.Enums;
using mytest.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mytest.Application.Commands.CreatePessoa
{
    public class CreatePessoaCommandHandler : IRequestHandler<CreatePessoaCommand, Unit>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ILogRepository _logRepository;

        public CreatePessoaCommandHandler(IPessoaRepository pessoaRepository, ILogRepository logRepository)
        {
            _pessoaRepository = pessoaRepository;
            _logRepository = logRepository;
        }

        public async Task<Unit> Handle(CreatePessoaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Pessoa pessoa = new Pessoa(request.Nome, request.CpfCnpj, request.Email, request.Telefone);

                await _pessoaRepository.AdicionarPessoaAsync(pessoa);
                await _logRepository.AdicionarLogAsync(new Log(TipoAcaoLogEnum.CadastrarPessoa.ToString(), StatusLogEnum.Sucesso.ToString(), $"Pessoa de id {pessoa.Id}, cadastrada com sucesso"));


            }
            catch (Exception ex)
            {
                await _logRepository.AdicionarLogAsync(new Log(TipoAcaoLogEnum.CadastrarPessoa.ToString(), StatusLogEnum.Falha.ToString(), $"Uma exceção foi gerada ao cadastrar o objeto ex=> {ex.Message.ToString()}"));
            }
            return Unit.Value;
        }
    }
}
