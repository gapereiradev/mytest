using MediatR;
using mytest.Application.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Application.Commands.CreateVenda
{
    public class CreateVendaCommand : IRequest<Unit>
    {
        public CreateVendaCommand()
        {

        }
        public CreateVendaCommand(int compradorId, int produtoId, int quantidade)
        {
            CompradorId = compradorId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
        }
        public int CompradorId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
