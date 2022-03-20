using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinBank
{
    public class ExtratoInvestimento
    {
        public string TipoAplicacao { get; set; }
        public DateTime DataAplicacao { get; set; }

        public DateTime DataRetirada { get; set; }
        public decimal Valor { get; set; }

        public ExtratoInvestimento(string operacao, DateTime dataAplicacao, decimal valor)
        {
            TipoAplicacao = operacao;
            Valor = valor;
            DataAplicacao = dataAplicacao;
        }

        public ExtratoInvestimento(string operacao, DateTime dataAplicacao, decimal valor, DateTime dataRetirada)
        {
            TipoAplicacao = operacao;
            Valor = valor;
            DataAplicacao = dataAplicacao;
            DataRetirada = dataRetirada;
        }
    }
}
