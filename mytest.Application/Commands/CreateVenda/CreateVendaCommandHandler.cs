using MediatR;
using mytest.Application.Models.View;
using mytest.Core.Entities;
using mytest.Core.Enums;
using mytest.Core.Repositories;
using mytest.Infra.CloudServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mytest.Application.Commands.CreateVenda
{
    public class CreateVendaCommandHandler : IRequestHandler<CreateVendaCommand, Unit>
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEmailServices _emailService;
        private readonly ILogRepository _logRepository;
        public CreateVendaCommandHandler(IVendaRepository vendaRepository, IProdutoRepository produtoRepository, IEmailServices emailService, ILogRepository logRepository)
        {
            _vendaRepository = vendaRepository;
            _produtoRepository = produtoRepository;
            _emailService = emailService;
            _logRepository = logRepository;
        }
        public async Task<Unit> Handle(CreateVendaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Produto produto = await _produtoRepository.GetByIdAsync(request.ProdutoId);
                if (produto.RemoverDoEstoque(request.Quantidade))
                {
                    Venda venda = new Venda(request.CompradorId, request.ProdutoId, request.Quantidade, produto.Valor);
                    venda.ConcluirVenda();
                    await _vendaRepository.AddAsync(venda);
                    //_emailService.NotificarVenda();
                    await _logRepository.AdicionarLogAsync(new Log(TipoAcaoLogEnum.CadastrarVenda.ToString(), StatusLogEnum.Sucesso.ToString(), $"Venda de id {venda.Id} cadastrada com sucesso"));
                }
                else
                {
                    await _logRepository.AdicionarLogAsync(new Log(TipoAcaoLogEnum.CadastrarVenda.ToString(), StatusLogEnum.Warning.ToString(), "Não foi localizado produto com o id encaminhado"));
                }
            }
            catch (Exception ex)
            {
                await _logRepository.AdicionarLogAsync(new Log(TipoAcaoLogEnum.CadastrarVenda.ToString(), StatusLogEnum.Falha.ToString(), $"Uma exceção foi gerada ao cadastrar o objeto ex=> {ex.Message.ToString()}"));
            }
            return Unit.Value;

        }
    }
}
