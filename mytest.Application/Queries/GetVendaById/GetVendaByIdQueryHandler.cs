using MediatR;
using mytest.Application.Models.View;
using mytest.Core.Repositories;
using mytest.Infra.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mytest.Application.Queries.GetVendaById
{
    public class GetVendaByIdQueryHandler : IRequestHandler<GetVendaByIdQuery, VendaViewModel>
    {
        private readonly IVendaRepository _vendaRepository;
        public GetVendaByIdQueryHandler(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public async Task<VendaViewModel> Handle(GetVendaByIdQuery request, CancellationToken cancellationToken)
        {
            var venda = await _vendaRepository.GetByIdAsync(request.Id);
            if (venda == null)
            {
                return null;
            }

            return new VendaViewModel(venda.Id, venda.CompradorId, venda.ProdutoId);
        }
    }
}
