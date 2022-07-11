using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Application.Commands.CreateProduto
{
    public class CreateProdutoCommand : IRequest<Unit>
    {
        public CreateProdutoCommand()
        {

        }
        public CreateProdutoCommand(string nome, decimal valor, int quantidade, int pessoaId)
        {
            Nome = nome;
            Valor = valor;
            Quantidade = quantidade;
            PessoaId = pessoaId;
        }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public int PessoaId { get; set; }
    }
}
