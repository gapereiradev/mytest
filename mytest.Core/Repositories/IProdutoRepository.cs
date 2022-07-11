using mytest.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Core.Repositories
{
    public interface IProdutoRepository
    {
        Task AdicionarProdutoAsync(Produto produto);
        Task<Produto> GetByIdAsync(int id);
        Task<List<Produto>> GetAllAsync();

    }
}
