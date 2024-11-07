using System.Globalization;

namespace Questao1
{
    public class ContaBancaria
    {
        // Propriedades
        public int NumeroConta { get; private set; }
        public string NomeTitular { get; set; }
        private double Saldo;

        // Construtores
        public ContaBancaria(int numeroConta, string nomeTitular)
        {
            NumeroConta = numeroConta;
            NomeTitular = nomeTitular;
            Saldo = 0.0;
        }

        public ContaBancaria(int numeroConta, string nomeTitular, double depositoInicial) : this(numeroConta, nomeTitular)
        {
            Deposito(depositoInicial);
        }

        // Métodos
        public void Deposito(double valor)
        {
            Saldo += valor;
        }

        public void Saque(double valor)
        {
            const double taxaSaque = 3.50;
            Saldo -= (valor + taxaSaque);
        }

        public override string ToString()
        {
            return $"Conta {NumeroConta}, Titular: {NomeTitular}, Saldo: $ {Saldo.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
