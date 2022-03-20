namespace DEVinBank
{
    public class Conta
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public decimal RendaMensal { get; set; }
        public int NumConta { get; set; }
        public KeyValuePair<int, string> Agencia { get; set; }
        public decimal Saldo { get; set; }

        public List<Extrato> Extrato = new List<Extrato>();

        public Conta(string nome, string cpf, string endereco, decimal rendaMensal, int numConta, KeyValuePair<int, string> agencia, decimal saldo)
        {
            Nome = nome;
            CPF = cpf; 
            Endereco = endereco;
            RendaMensal = rendaMensal;
            NumConta = numConta;
            Agencia = agencia;
            Saldo = saldo;
        }


        public virtual void Saque(decimal valor)
        {
            if (Saldo > valor)
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

        public void Deposito(decimal valor, string tipo = null)
        {
            Saldo += valor;
            if (tipo == null)
            {
                Extrato.Add(new Extrato("Depósito", DateTime.Now, valor));
                Console.WriteLine("\nDepósito efetuado com sucesso!\n");
            } else
            {
                Extrato.Add(new Extrato(tipo, DateTime.Now, valor));
                Console.WriteLine($"\n{tipo} efetuado(a) com sucesso!\n");
            }
        }

        public string MostrarSaldo()
        {
            return $"O valor do saldo é de R$ {Saldo}";
        }

        public List<string> MostrarExtrato()
        {
            var list = new List<string>();
            list.Add($"OPERAÇÂO | DATA  |  VALOR");
            foreach (Extrato extrato in Extrato)
            {
                list.Add($"{extrato.TipoOperacao}  |  {extrato.Data} | R${extrato.Valor}");
            }

            return list;
        }

        public virtual string AlterarDados(string nome, string endereco, decimal renda)
        {
            Nome = nome;
            Endereco = endereco;
            RendaMensal = renda;

            return "Dados alterados com sucesso!";
        }

        public virtual Transferencia Transferencia(Conta destino, decimal valor)
        {
            if (Saldo > valor)
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



