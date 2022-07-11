using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Application.Models.Input
{
    public class PessoaInputModel
    {
        public PessoaInputModel()
        {

        }
        public PessoaInputModel(string nome, string cpfCnpj, string email, string telefone)
        {
            Nome = nome;
            CpfCnpj = cpfCnpj;
            Email = email;
            Telefone = telefone;
        }
        public int Id { get; private set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
