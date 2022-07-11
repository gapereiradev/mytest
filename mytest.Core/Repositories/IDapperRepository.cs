using mytest.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mytest.Core.Repositories
{
    public interface IDapperRepository
    {
        Task<List<FluxoDeCaixaDTO>> GetFluxoDeCaixaByPessoaId(int pessoaId);
    }
}
