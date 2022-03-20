using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinBank
{
    public class LCI : Investimento
    {
        public LCI(decimal valor, DateTime data)
        {
            Valor = valor;
            DataAplicacao = data;
            TempoMininoEmMeses = 6;
            RentabilidadeAnual = 8M;
        }
    }
}
