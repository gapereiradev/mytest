using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Application.Models.ViewModel
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel(int id, string nome, decimal valor, int quantidade)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
            Quantidade = quantidade;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }

        public void AddEstoque(int quantidade)
        {
            Quantidade += quantidade;
        }

        public void RemoverEstoque(int quantidade)
        {
            Quantidade -= quantidade;
        }
    }
}
