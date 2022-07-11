using mytest.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mytest.Core.Entities
{
    public class Log : BaseEntity
    {
        public Log(string acao, string statusLog, string mensagem)
        {
            Acao = acao;
            StatusLog = statusLog;
            Mensagem = mensagem;
        }

        public string Acao { get; private set; }
        public string StatusLog { get; private set; }
        public string Mensagem { get; private set; }
    }
}
