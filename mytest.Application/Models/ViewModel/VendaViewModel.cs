using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Application.Models.View
{
    public class VendaViewModel
    {
        public VendaViewModel()
        {

        }
        public VendaViewModel(int id, int compradorId, int produtoId)
        {
            Id = id;
            CompradorId = compradorId;
            ProdutoId = produtoId;
        }
        public int Id { get; set; }
        public int CompradorId { get; set; }
        public int ProdutoId { get; set; }

    }
}
