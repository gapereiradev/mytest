using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using mytest.Core.DTOs;
using mytest.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Infra.Persistence.Repositories
{
    public class DapperRepository : IDapperRepository
    {
        private readonly string _connectionString;
        public DapperRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("mytestCs");
        }

        public async Task<List<FluxoDeCaixaDTO>> GetFluxoDeCaixaByPessoaId(int pessoaId)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = $@"SELECT CompradorId as 'Id', MONTH(DataCriacao) as 'Mes', YEAR(DataCriacao) as 'Ano', SUM(Total) as 'Total', 'COMPRAS' as 'Tipo' 
                            FROM Vendas WHERE CompradorId = 1 and StatusVenda = 1 GROUP BY MONTH(DataCriacao), YEAR(DataCriacao), CompradorId
                                    UNION ALL                          
                            SELECT ve.CompradorId as 'Id', MONTH(ve.DataCriacao) as 'Mes', YEAR(ve.DataCriacao) as 'Ano', SUM(ve.Total) as 'Total', 
                            'VENDAS' as 'Tipo' FROM Vendas ve
                            INNER JOIN Produtos po on (ve.ProdutoId = po.Id)
                            WHERE po.PessoaId = 1
                            GROUP BY MONTH(ve.DataCriacao), YEAR(ve.DataCriacao), ve.CompradorId
                            ORDER BY Mes, Ano";

                var fluxoDeCaixa = await sqlConnection.QueryAsync<FluxoDeCaixaDTO>(script);

                return fluxoDeCaixa.ToList();
            }
        }
    }
}
