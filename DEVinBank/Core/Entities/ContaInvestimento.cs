using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinBank
{
    public class ContaInvestimento : Conta
    {
        public LCI LCI;
        public LCA LCA;
        public CDB CDB;

        public List<ExtratoInvestimento> ExtratoInvestimento = new List<ExtratoInvestimento>();
        public ContaInvestimento(string nome, string cpf, string endereco, decimal rendaMensal, int numConta, KeyValuePair<int, string> agencia, decimal saldo) : base(nome, cpf, endereco, rendaMensal, numConta, agencia, saldo)
        {
        }

        public void SimulaLCI(int meses, decimal valor)
        {
            SimulaRendimento("LCI", meses, valor, 8M);
            if (LCI == null)
            {
                Investir("LCI", valor);
            }
        }

        public void SimulaLCA(int meses, decimal valor)
        {
            SimulaRendimento("LCA", meses, valor, 9M);
            if (LCA == null)
            {
                Investir("LCA", valor);
            }
        }

        public void SimulaCDB(int meses, decimal valor)
        {
            SimulaRendimento("CDB", meses, valor, 10M);
            if (CDB == null)
            {
                Investir("CDB", valor);
            }
        }

        private void SimulaRendimento(string tipo, int meses, decimal valor, decimal rentabilidadeAnual)
        {

            var rendimento = Rendimento(valor, rentabilidadeAnual, meses);

            Console.WriteLine($"O rendimento de {tipo} no valor de R$ {valor}, por {meses} meses, na rentabilidade de {rentabilidadeAnual}% ao ano, é de R$ {rendimento}\n\n");
        }

        private decimal Rendimento(decimal valor, decimal rentabilidadeAnual, int meses)
        {
            var taxaJuros = (rentabilidadeAnual / 12);
            var taxa = decimal.ToDouble((1 + (taxaJuros / 100)));
            var calculo = (decimal)Math.Pow(taxa, meses);

            return valor * calculo;
        }


        private void Investir(string tipo, decimal valor)
        {
            var opcao = 0;
            Console.WriteLine("Deseja investir?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");

            opcao = int.Parse(Console.ReadLine());


            if (Saldo < valor && opcao == 1)
            {
                    Console.WriteLine("O saldo disponível é maior que o valor solicidato");
                    Console.WriteLine($"O saldo atual é de R$ {Saldo}. Gostaria de investir o saldo total atual?");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não");

                    opcao = int.Parse(Console.ReadLine());


                if (opcao == 1)
                {
                    valor = Saldo;
                }
            }

            if (opcao == 1)
            {
                var data = DateTime.Now;
                switch (tipo)
                {
                    case "LCI":
                        LCI = new LCI(valor, data);
                        ExtratoInvestimento.Add(new ExtratoInvestimento("LCI", data, valor));
                        break;

                    case "LCA":
                        LCA = new LCA(valor, DateTime.Now);
                        ExtratoInvestimento.Add(new ExtratoInvestimento("LCA", data, valor));
                        break;

                    case "CDB":
                        CDB = new CDB(valor, DateTime.Now);
                        ExtratoInvestimento.Add(new ExtratoInvestimento("CDB", data, valor));
                        break;

                }

                Console.WriteLine("Investimento efetuado com sucesso.\n\n");
                Extrato.Add(new Extrato($"Investimento em {tipo}", DateTime.Now, valor));
                Saldo -= valor;
            }
        }

        public void Resgatar(string tipo, DateTime dataAtual)
        {
            switch (tipo)
            {
                case "LCI":
                    if (ValidaResgate(LCI.DataAplicacao, dataAtual, LCI.TempoMininoEmMeses))
                    {
                        var rendimento = Rendimento(LCI.Valor, LCI.RentabilidadeAnual, DiferencaEmMeses(LCI.DataAplicacao, dataAtual));
                        Saldo += rendimento;
                        Extrato.Add(new Extrato("Resgate de LCI", dataAtual, rendimento));
                        ExtratoInvestimento.Add(new ExtratoInvestimento("LCI", LCI.DataAplicacao, rendimento, dataAtual));
                        Console.WriteLine("\nInvestimento resgatado com sucesso.\n\n");
                    }
                    else
                    {
                        Console.WriteLine("Tempo mínimo de resgate não alcançado.\n\n");
                    }
                    break;

                case "LCA":
                    if (ValidaResgate(LCA.DataAplicacao, dataAtual, LCA.TempoMininoEmMeses))
                    {
                        var rendimento = Rendimento(LCA.Valor, LCA.RentabilidadeAnual, DiferencaEmMeses(LCA.DataAplicacao, dataAtual));
                        Saldo += rendimento;
                        Extrato.Add(new Extrato("Resgate de LCA", dataAtual, rendimento));
                        ExtratoInvestimento.Add(new ExtratoInvestimento("LCA", LCA.DataAplicacao, rendimento, dataAtual));
                        Console.WriteLine("\nInvestimento resgatado com sucesso.\n\n");
                    }
                    else
                    {
                        Console.WriteLine("Tempo mínimo de resgate não alcançado.\n\n");
                    }
                    break;

                case "CDB":
                    if (ValidaResgate(CDB.DataAplicacao, dataAtual, CDB.TempoMininoEmMeses))
                    {
                        var rendimento = Rendimento(CDB.Valor, CDB.RentabilidadeAnual, DiferencaEmMeses(CDB.DataAplicacao, dataAtual));
                        Saldo += rendimento;
                        Extrato.Add(new Extrato("Resgate de CDB", dataAtual, rendimento));
                        ExtratoInvestimento.Add(new ExtratoInvestimento("LCA", CDB.DataAplicacao, rendimento, dataAtual));
                        Console.WriteLine("\nInvestimento resgatado com sucesso.\n\n");
                    }
                    else
                    {
                        Console.WriteLine("Tempo mínimo de resgate não alcançado.\n\n");
                    }
                    break;

            }
        }




        private bool ValidaResgate(DateTime dataAplicacao, DateTime dataAtual, int tempoDeResgate)
        {
            return tempoDeResgate < DiferencaEmMeses(dataAplicacao, dataAtual);
        }

        public static int DiferencaEmMeses(DateTime dataInicial, DateTime dataFinal)
        {
            int diferencaEmMeses = 12 * (dataInicial.Year - dataFinal.Year) + dataInicial.Month - dataFinal.Month;
            return Math.Abs(diferencaEmMeses);
        }
    }
}
