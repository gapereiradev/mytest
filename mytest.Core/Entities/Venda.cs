using mytest.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Core.Entities
{
    public class Venda : BaseEntity
    {
        public Venda(int compradorId, int produtoId, int quantidade, decimal valorUnitario)
        {
            CompradorId = compradorId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public int CompradorId { get; private set; }
        public Pessoa PessoaCompradora { get; private set; }

        public int ProdutoId { get; private set; }
        public Produto ProdutoVendidoId { get; private set; }

        public int Quantidade { get; private set; }

        public string HashCupomFiscal { get; private set; }

        public StatusVendaEnum StatusVenda { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public decimal Total { get; private set; }

        public void ConcluirVenda()
        {
            StatusVenda = StatusVendaEnum.Concluida;
            GenerateHashCupomFiscal();
            CalcularValorTotal();
        }

        public void CancelarVenda()
        {
            StatusVenda = StatusVendaEnum.Cancelada;
        }

        private void GenerateHashCupomFiscal()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 15)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            HashCupomFiscal = result;
        }

        private void CalcularValorTotal()
        {
            Total = ValorUnitario * Quantidade;
        }

    }
}
