using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinBank
{
    public class Investimento
    {
        public decimal Valor { get; set; }
        public DateTime DataAplicacao { get; set; }
        public decimal RentabilidadeAnual { get; set; }
        public int TempoMininoEmMeses   { get; set; }

    }
}
