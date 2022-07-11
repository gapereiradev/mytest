using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Application.Models.View
{
    public class PessoaViewModel
    {
        public PessoaViewModel(int id, string nome, string cpfCnpj, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            CpfCnpj = cpfCnpj;
            Email = email;
            Telefone = telefone;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
    }
}
