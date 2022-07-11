using Microsoft.EntityFrameworkCore;
using mytest.Core.Entities;
using mytest.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Infra.Persistence.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly mytestDbContext _dbContext;

        public ProdutoRepository(mytestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AdicionarProdutoAsync(Produto produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Produto>> GetAllAsync()
        {
            return await _dbContext.Produtos.ToListAsync();
        }

        public async Task<Produto> GetByIdAsync(int id)
        {
            return await _dbContext.Produtos.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
    }
}
