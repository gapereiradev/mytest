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
    public class PessoaRepository : IPessoaRepository
    {
        private readonly mytestDbContext _dbContext;
        
        public PessoaRepository(mytestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AdicionarPessoaAsync(Pessoa pessoa)
        {
            await _dbContext.Pessoas.AddAsync(pessoa);
            await _dbContext.SaveChangesAsync();

        }
        public async Task<Pessoa> GetByIdAsync(int id)
        {
            return await _dbContext.Pessoas.FirstOrDefaultAsync(p => p.Id == id);
        }        
        public async Task<List<Pessoa>> GetAllAsync()
        {
            return await _dbContext.Pessoas.ToListAsync();
        }


        

    }
}
