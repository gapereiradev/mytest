using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Core.Entities
{
    public class Produto : BaseEntity
    {
        public Produto(string nome, decimal valor, int quantidadeEmEstoque, int pessoaId)
        {
            Nome = nome;
            Valor = valor;
            QuantidadeEmEstoque = quantidadeEmEstoque;
            PessoaId = pessoaId;
        }

        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
        public int QuantidadeEmEstoque { get; private set; }
        public bool Active { get; private set; }
        public int PessoaId { get; private set; }
        public Pessoa Pessoa { get; private set; }

        public List<Venda> VendasProduto { get; private set; }

        public void CriarProduto()
        {
            Active = true;
        }

        public void CancelarProduto()
        {
            Active = false;
        }

        public bool RemoverDoEstoque(int quantidade)
        {
            if (QuantidadeEmEstoque - quantidade > 0)
            {
                QuantidadeEmEstoque -= quantidade;
                return true;
            }
            return false;
        }

    }
}
