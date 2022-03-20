using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinBank
{
    public class ContaCorrente : Conta
    {
        public decimal ChequeEspecial { get; set; }

        public ContaCorrente(string nome, string cpf, string endereco, decimal rendaMensal, int numConta, KeyValuePair<int, string> agencia, decimal saldo) : base(nome, cpf, endereco, rendaMensal, numConta, agencia, saldo)
        {
            ChequeEspecial = rendaMensal * 0.1M;
        }

        public override void Saque(decimal valor)
        {
            if (Saldo + ChequeEspecial > valor)
            {
                Saldo -= valor;
                Extrato.Add(new Extrato("Saque", DateTime.Now, valor * -1));
                Extrato.Add(new Extrato("Saque", DateTime.Now, valor * -1));
                Console.WriteLine("\nSaque efetuado com sucesso!\n");
            }
            else
            {
                Console.WriteLine("\nSaldo insuficiente para saque!\n");
            }
        }

        public override string AlterarDados(string nome, string endereco, decimal renda)
        {
            Nome = nome;
            Endereco = endereco;
            RendaMensal = renda;
            ChequeEspecial = RendaMensal * 0.1M;

            return "Dados alterados com sucesso!";
        }

        public override Transferencia Transferencia(Conta destino, decimal valor)
        {
            if (Saldo + ChequeEspecial > valor)
            {
                Saldo -= valor;

                var data = DateTime.Now;
                Extrato.Add(new Extrato("Transferência", data, valor * -1));
                return new Transferencia(this, destino, data, valor);
            }
            else
            {
                throw new Exception("Saldo insuficiente para transferência!");
            }
        }
    }
}
