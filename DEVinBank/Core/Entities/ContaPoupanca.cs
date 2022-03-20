using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinBank
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca(string nome, string cpf, string endereco, decimal rendaMensal, int numConta, KeyValuePair<int, string> agencia, decimal saldo) : base(nome, cpf, endereco, rendaMensal, numConta, agencia, saldo)
        {           
        }

        public string SimulaRendimento(int meses, decimal rentabilidadeAnual)
        {
            decimal tempoEmAno = meses / 12;
            decimal rendimento = rentabilidadeAnual * tempoEmAno;

            return $"Em {meses} meses, o rendimento do saldo atual {Saldo}, na rentabilidade de {rentabilidadeAnual} ao ano, será de R$ {Saldo * rendimento}";
        }
    }
}
