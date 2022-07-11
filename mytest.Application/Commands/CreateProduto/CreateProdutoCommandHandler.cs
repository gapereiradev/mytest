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

namespace mytest.Application.Commands.CreateProduto
{
    public class CreateProdutoCommandHandler : IRequestHandler<CreateProdutoCommand, Unit>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogRepository _logRepository;
        public CreateProdutoCommandHandler(IProdutoRepository produtoRepository, ILogRepository logRepository)
        {
            _produtoRepository = produtoRepository;
            _logRepository = logRepository;
        }

        public async Task<Unit> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Produto produto = new Produto(request.Nome, request.Valor, request.Quantidade, request.PessoaId);
                produto.CriarProduto();

                await _produtoRepository.AdicionarProdutoAsync(produto);
                await _logRepository.AdicionarLogAsync(new Log(TipoAcaoLogEnum.CadastrarProduto.ToString(), StatusLogEnum.Sucesso.ToString(), $"Produto de id {produto.Id}, cadastrado com sucesso"));
            }
            catch (Exception ex)
            {
                await _logRepository.AdicionarLogAsync(new Log(TipoAcaoLogEnum.CadastrarProduto.ToString(), StatusLogEnum.Falha.ToString(), $"Uma exceção foi gerada ao cadastrar o objeto ex=> {ex.Message.ToString()}"));
            }
            return Unit.Value;
        }
    }
}
