using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() { DataCriacao = DateTime.Now; }
        public int Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
    }
}
