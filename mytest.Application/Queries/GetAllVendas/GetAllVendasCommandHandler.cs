using MediatR;
using mytest.Application.Models.View;
using mytest.Core.Entities;
using mytest.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mytest.Application.Queries.GetAllVendas
{
    public class GetAllVendasCommandHandler : IRequestHandler<GetAllVendasCommand, List<VendaViewModel>>
    {
        private readonly IVendaRepository _vendaRepository;
        public GetAllVendasCommandHandler(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public async Task<List<VendaViewModel>> Handle(GetAllVendasCommand request, CancellationToken cancellationToken)
        {
            var vendas = await _vendaRepository.GetAllAsync();
            if (vendas == null)
            {
                return null;
            }

            List<VendaViewModel> vendasViewModel = new List<VendaViewModel>();
            foreach (Venda venda in vendas)
            {
                vendasViewModel.Add(new VendaViewModel(venda.Id, venda.CompradorId, venda.ProdutoId));
            }

            return vendasViewModel;
        }
    }
}
