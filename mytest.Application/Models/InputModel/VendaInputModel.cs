using mytest.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Application.Models.Input
{
    public class VendaInputModel
    {
        public int VendedorId { get; private set; }
        public int CompradorId { get; private set; }
        public string HashCupomFiscal { get; private set; }
        public StatusVendaEnum StatusVenda { get; private set; }
    }
}
