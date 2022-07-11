using mytest.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Core.Repositories
{
    public interface IVendaRepository
    {
        Task AddAsync(Venda venda);
        Task<List<Venda>> GetAllAsync();
        Task<Venda> GetByIdAsync(int id);
    }
}
