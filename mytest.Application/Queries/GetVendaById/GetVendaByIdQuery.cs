using MediatR;
using mytest.Application.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Application.Queries.GetVendaById
{
    public class GetVendaByIdQuery : IRequest<VendaViewModel>
    {
        public GetVendaByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}