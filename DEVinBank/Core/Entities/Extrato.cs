using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinBank
{
    public class Extrato
    {
        public string TipoOperacao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }

        public Extrato(string operacao, DateTime data, decimal valor)
        {
            TipoOperacao = operacao;
            Valor = valor;
            Data = data;
        }
    }
}
