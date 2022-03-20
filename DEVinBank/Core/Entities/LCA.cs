using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinBank
{
    public class LCA : Investimento
    {
        public LCA(decimal valor, DateTime data)
        {
            Valor = valor;
            DataAplicacao = data;
            TempoMininoEmMeses = 12;
            RentabilidadeAnual = 9M;
        }
    }
}
