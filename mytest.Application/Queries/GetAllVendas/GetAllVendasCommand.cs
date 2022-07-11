using MediatR;
using mytest.Application.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Application.Queries.GetAllVendas
{
    public class GetAllVendasCommand : IRequest<List<VendaViewModel>>
    {
    }
}
