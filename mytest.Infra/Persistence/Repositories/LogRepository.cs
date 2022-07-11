using mytest.Core.Entities;
using mytest.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Infra.Persistence.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly mytestDbContext _dbContext;
        public LogRepository(mytestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AdicionarLogAsync(Log log)
        {
            await _dbContext.Logs.AddAsync(log);
            await _dbContext.SaveChangesAsync();
        }
    }
}
