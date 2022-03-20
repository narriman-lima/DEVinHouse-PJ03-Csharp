namespace DEVinBank
{
    class Program
    {
        public static List<KeyValuePair<int, string>> agencias = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(001, "Florianópolis"),
                new KeyValuePair<int, string>(002, "São José"),
                new KeyValuePair<int, string>(003, "Biguaçu")
            };

        public static List<Conta> contas = new List<Conta>();

        public static int contadorNumeroConta = 1;

        public static HistoricoDeTransferencias historicoTransferencias = new HistoricoDeTransferencias();

        public static DateTime dataAtual = DateTime.Now;
        static void Main(string[] args)
        {
            // Contas Corrente
            ContaCorrente ContaCC1 = new ContaCorrente("Maria José", "987456321", "Rua Um, 17", 2500M, contadorNumeroConta++, agencias[0], 1500M);
            contas.Add(ContaCC1);
            ContaCorrente ContaCC2 = new ContaCorrente("Lurdes Pereira", "1245677856", "Rua Dois, 47", 1500M, contadorNumeroConta++, agencias[2], 100M);
            contas.Add(ContaCC2);

            // Contas Correntes Transações
            ContaCC1.Deposito(300M);
            ContaCC1.Saque(150M);
            ContaCC1.Saque(4000M);
            ContaCC1.Deposito(600M);
            ContaCC1.Deposito(225M);
            ContaCC1.Saque(332M);

            ContaCC2.Saque(230M);

            // Conta Poupança
            ContaPoupanca ContaPP = new ContaPoupanca("Lorem Ipsum", "45645646", "Rua Três, 38", 500M, contadorNumeroConta++, agencias[1], 1800M);
            contas.Add(ContaPP);

            //Conta de Investimento
            ContaInvestimento ContaInv = new ContaInvestimento("Ademar Barbosa", "456464", "Rua Quatro, 44", 4000M, contadorNumeroConta++, agencias[2], 400M);
            contas.Add(ContaInv);

            int opcao = 10;

            while (opcao != 0)
            {
                Console.Clear();
                Console.WriteLine("-------------------DEVinBank-------------------\r\n");
                Console.WriteLine($"Data do Sistema: {dataAtual}\n");
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine("1 - Acesso a Conta");
                Console.WriteLine("2 - Acesso ao Sistema");
                Console.WriteLine("0 - Sair");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o número da Conta:");
                        var numConta = int.Parse(Console.ReadLine());
                        var conta = encontrarConta(numConta);

                        if (conta != null)
                        {
                            Console.WriteLine("Conta encontrada");
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadLine();

                            menuConta(conta);
                        }
                        else
                        {
                            Console.WriteLine("Conta não encontrada. Tente novamente!");
                        }
                        break;

                    case 2:
                        menuSistema();
                        break;
                }
            }
        }

        public static void menuSistema()
        {
            int opcao = 99;

            while (opcao != 0)
            {
                Console.Clear();
                Console.WriteLine("-------------------DEVinBank-------------------\r\n");
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine("1 - Listar todas as contas");
                Console.WriteLine("2 - Contas com Saldo Negativo");
                Console.WriteLine("3 - Transações de um cliente");
                Console.WriteLine("4 - Adicionar 1 ano a data atual do sistema");
                Console.WriteLine("0 - Voltar");


                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        relatorioTodasContas(contas);
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        geraRelatorioContaSaldoNegativo(contas);
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Digite o número da conta do cliente:");
                        var numConta = int.Parse(Console.ReadLine());
                        var contaDestino = encontrarConta(numConta);
                        if (contaDestino != null)
                        {
                            Console.WriteLine("Conta encontrada:");
                            Console.WriteLine($"Nome: {contaDestino.Nome}");
                            Console.WriteLine($"Agência: {contaDestino.Agencia.Key.ToString().PadLeft(3, '0')} - {contaDestino.Agencia.Value}");

                            geraExtrato(contaDestino.MostrarExtrato());
                        }
                        else
                        {
                            Console.WriteLine("Conta não encontrada. Tente novamente!");
                        }
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        dataAtual = dataAtual.AddYears(1);
                        Console.WriteLine($"Nova data do sistema? {dataAtual}");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;

                }
            }
        }

        public static void menuConta(Conta conta)
        {

            int opcao = 99;

            while (opcao != 0)
            {
                Console.Clear();
                Console.WriteLine("-------------------DEVinBank-------------------\r\n");
                Console.WriteLine($"Olá, {conta.Nome}");
                Console.WriteLine($"Saldo: R${conta.Saldo}");
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine("1 - Saque");
                Console.WriteLine("2 - Depósito");
                Console.WriteLine("3 - Extrato");
                Console.WriteLine("4 - Transferência");
                Console.WriteLine("5 - Dados da Conta");
                Console.WriteLine("6 - Alterar dados Cadastrais");

                if (conta is not ContaCorrente)
                {
                    Console.WriteLine("7 - Mais opções");
                }
                Console.WriteLine("0 - Voltar");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("-------------------Saque-------------------\r\n");
                        Console.WriteLine($"Saldo: R${conta.Saldo}");
                        Console.WriteLine("Informe o valor desejado para saque:");
                        var valorSaque = decimal.Parse(Console.ReadLine());
                        conta.Saque(valorSaque);
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;


                    case 2:
                        Console.Clear();
                        Console.WriteLine("-------------------Depósito-------------------\r\n");
                        Console.WriteLine($"Saldo: R${conta.Saldo}");
                        Console.WriteLine("Informe o valor desejado para depósito:");
                        var valorDeposito = decimal.Parse(Console.ReadLine());
                        conta.Deposito(valorDeposito);
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;


                    case 3:
                        Console.Clear();
                        Console.WriteLine("-------------------Extrato-------------------\r\n");
                        geraExtrato(conta.MostrarExtrato());
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("-------------------Transferência-------------------\r\n");
                        Console.WriteLine($"Saldo: R${conta.Saldo}");
                        Console.WriteLine("Digite o número da Conta de destino:");
                        var numConta = int.Parse(Console.ReadLine());
                        var contaDestino = encontrarConta(numConta);
                        if (contaDestino != null)
                        {
                            Console.WriteLine("Conta encontrada:");
                            Console.WriteLine($"Nome: {contaDestino.Nome}");
                            Console.WriteLine($"Agência: {contaDestino.Agencia.Key.ToString().PadLeft(3, '0')} - {contaDestino.Agencia.Value}");

                            Console.WriteLine("\nInforme o valor a ser transferido: ");
                            var valor = decimal.Parse(Console.ReadLine());

                            historicoTransferencias.Historico.Add(conta.Transferencia(contaDestino, valor));
                            foreach (Conta item in contas)
                            {
                                if (item.NumConta == numConta)
                                {
                                    item.Deposito(valor, "Transferência");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Conta não encontrada. Tente novamente!");
                        }
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("------------------- Dados da Conta-------------------\r\n");
                        Console.WriteLine($"Nome: {conta.Nome}");
                        Console.WriteLine($"CPF: {conta.CPF}");
                        Console.WriteLine($"Endereço: {conta.Endereco}");
                        Console.WriteLine($"Renda: R${conta.RendaMensal}");
                        Console.WriteLine($"Número da Conta: {conta.NumConta}");
                        Console.WriteLine($"Agência: {conta.Agencia.Key.ToString().PadLeft(3, '0')} - {conta.Agencia.Value}");
                        if (conta is ContaCorrente)
                        {
                            Console.WriteLine($"Cheque especial: {(conta as ContaCorrente).ChequeEspecial}");
                        }
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;

                    case 6:
                        Console.Clear();
                        Console.WriteLine("------------------- Alterar dados Cadastrais-------------------\r\n");
                        Console.WriteLine("Informe o nome:");
                        var nome = Console.ReadLine();
                        Console.WriteLine("Informe o endereço:");
                        var endereco = Console.ReadLine();
                        Console.WriteLine("Informe a renda:");
                        var renda = decimal.Parse(Console.ReadLine());

                        Console.WriteLine(conta.AlterarDados(nome, endereco, renda));

                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;

                    case 7:
                        if (conta is ContaPoupanca)
                        {
                            menuPoupanca(conta as ContaPoupanca);
                        }

                        if (conta is ContaInvestimento)
                        {
                            menuInvetimento(conta as ContaInvestimento);
                        }
                        break;

                }
            }
        }

        public static void menuPoupanca(ContaPoupanca conta)
        {

            int opcao = 99;

            while (opcao != 0)
            {
                Console.Clear();
                Console.WriteLine("-------------------Conta Poupança-------------------\r\n");
                Console.WriteLine($"Olá, {conta.Nome}");
                Console.WriteLine($"Saldo: R${conta.Saldo}");
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine("1 - Simulação de Rendimento");
                Console.WriteLine("0 - Voltar");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Informe a quantidade de meses:");
                        var meses = int.Parse(Console.ReadLine());
                        Console.WriteLine("Informe a rentabilidade anual (sugestão, 10%a.a.):");
                        var rentabilidade = decimal.Parse(Console.ReadLine());
                        Console.WriteLine(conta.SimulaRendimento(meses, rentabilidade));
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;
                }

            }
        }

        public static void menuInvetimento(ContaInvestimento conta)
        {
            int opcao = 99;

            while (opcao != 0)
            {
                Console.Clear();
                Console.WriteLine("-------------------Conta de Investimentos-------------------\r\n");
                Console.WriteLine($"Olá, {conta.Nome}");
                Console.WriteLine($"Saldo: R${conta.Saldo}");
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine("1 - Simulação investimento LCI");
                Console.WriteLine("2 - Simulação investimento LCA");
                Console.WriteLine("3 - Simulação investimento CDB");
                Console.WriteLine("4 - Regastar investimento");
                Console.WriteLine("5 - Extrato de investimento");
                Console.WriteLine("0 - Voltar");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Informe a quantidade de meses:");
                        var mesesLCI = int.Parse(Console.ReadLine());
                        Console.WriteLine("Informe o valor:");
                        var valorLCI = decimal.Parse(Console.ReadLine());
                        conta.SimulaLCI(mesesLCI, valorLCI);
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Informe a quantidade de meses:");
                        var mesesLCA = int.Parse(Console.ReadLine());
                        Console.WriteLine("Informe o valor:");
                        var valorLCA = decimal.Parse(Console.ReadLine());
                        conta.SimulaLCA(mesesLCA, valorLCA);
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Informe a quantidade de meses:");
                        var mesesCDB = int.Parse(Console.ReadLine());
                        Console.WriteLine("Informe o valor:");
                        var valorCDB = decimal.Parse(Console.ReadLine());
                        conta.SimulaCDB(mesesCDB, valorCDB);
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Informe o tipo de Investimento (LCI, LCA ou CDB):");
                        var tipo = Console.ReadLine();
                        conta.Resgatar(tipo, dataAtual);
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Tipo Aplicação | Data Aplicação | Data  Resgate | Valor");
                        foreach (ExtratoInvestimento extrato in conta.ExtratoInvestimento)
                        {
                            Console.WriteLine($"{extrato.TipoAplicacao} | {extrato.DataAplicacao} | {extrato.DataRetirada} | {extrato.Valor}");
                        }
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;
                }

            }
        }


        public static Conta encontrarConta(int numero)
        {
            return contas.Find(conta => conta.NumConta == numero);
        }

        public static void geraExtrato(List<string> extrato)
        {
            foreach (string item in extrato)
            {
                Console.WriteLine(item);
            }
        }

        public static void relatorioTodasContas(List<Conta> contas)
        {
            var contasCorrente = contas.Where(conta => conta is ContaCorrente).ToList();
            var contasPoupanca = contas.Where(conta => conta is ContaPoupanca).ToList();
            var contasInvestimento = contas.Where(conta => conta is ContaInvestimento).ToList();
            Console.Clear();
            geraRelatorioConta(contasCorrente, "Conta Corrente");
            geraRelatorioConta(contasPoupanca, "Conta Poupança");
            geraRelatorioConta(contasInvestimento, "Conta de Investimento");
        }


        public static void geraRelatorioConta(List<Conta> contas, string tipo)
        {
            Console.WriteLine($"\n{ tipo }:");
            Console.WriteLine("Nome | Número Conta | Agência");
            foreach (Conta conta in contas)
            {
                Console.WriteLine($"{conta.Nome} | {conta.NumConta} | {conta.Agencia.Key.ToString().PadLeft(3, '0')} - {conta.Agencia.Value}");
            }
        }

        public static void geraRelatorioContaSaldoNegativo(List<Conta> contas)
        {
            var contasCorrenteSaldoNegativo = contas.Where(conta => conta is ContaCorrente && conta.Saldo < 0).ToList();
            Console.Clear();
            Console.WriteLine($"\nContas Correntes com Saldo Negativo:");
            Console.WriteLine("Nome | Número Conta | Agência | Saldo");
            foreach (Conta conta in contasCorrenteSaldoNegativo)
            {
                Console.WriteLine($"{conta.Nome} | {conta.NumConta} | {conta.Agencia.Key.ToString().PadLeft(3, '0')} - {conta.Agencia.Value} | R${ conta.Saldo }");
            }
        }
    }
}