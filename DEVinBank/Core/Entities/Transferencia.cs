using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinBank
{
    public class Transferencia
    {
        public Conta Origem { get; set; }
        public Conta Destino { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }


        public Transferencia (Conta origem, Conta destino, DateTime data, decimal valor)
        {
            Origem = origem;
            Destino = destino;
            Data = data;
            Valor = valor;
        }
    }
}
