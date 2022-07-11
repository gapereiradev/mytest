using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Application.Commands.CreatePessoa
{
    public class CreatePessoaCommand : IRequest<Unit>
    {
        public CreatePessoaCommand()
        {

        }

        public CreatePessoaCommand(string nome, string cpfCnpj, string email, string telefone)
        {
            Nome = nome;
            CpfCnpj = cpfCnpj;
            Email = email;
            Telefone = telefone;
        }

        public string Nome{ get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
