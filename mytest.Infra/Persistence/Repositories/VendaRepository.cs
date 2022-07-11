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
    public class VendaRepository : IVendaRepository
    {
        private readonly mytestDbContext _dbContext;

        public VendaRepository(mytestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Venda venda)
        {
            await _dbContext.Vendas.AddAsync(venda);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Venda>> GetAllAsync()
        {
            return await _dbContext.Vendas.ToListAsync();
        }

        public async Task<Venda> GetByIdAsync(int id)
        {
            return await _dbContext.Vendas.Where(v => v.Id == id).FirstOrDefaultAsync();
        }
    }
}
