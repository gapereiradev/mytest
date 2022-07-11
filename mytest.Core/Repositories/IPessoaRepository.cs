using mytest.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Core.Repositories
{
    public interface IPessoaRepository
    {
        Task AdicionarPessoaAsync(Pessoa pessoa);
        Task<Pessoa> GetByIdAsync(int id);
        Task<List<Pessoa>> GetAllAsync();

        //void AtualizarPessoaAsync(Pessoa pessoa);
    }
}
