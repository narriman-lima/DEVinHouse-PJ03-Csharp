using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinBank
{
    public class CDB : Investimento
    {
        public CDB(decimal valor, DateTime data)
        {
            Valor = valor;
            DataAplicacao = data;
            TempoMininoEmMeses = 36;
            RentabilidadeAnual = 10M;
        }
    }

}
