using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Core.Entities
{
    public class Pessoa : BaseEntity
    {
        public Pessoa(string nome, string cpfCnpj, string email, string telefone)
        {
            Nome = nome;
            CpfCnpj = cpfCnpj;
            Email = email;
            Telefone = telefone;
        }

        public string Nome { get;  set; }
        public string CpfCnpj { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public List<Venda> PessoasCompradoras { get; private set; }
        public List<Produto> ProdutosAnunciados { get; private set; }

    }
}
