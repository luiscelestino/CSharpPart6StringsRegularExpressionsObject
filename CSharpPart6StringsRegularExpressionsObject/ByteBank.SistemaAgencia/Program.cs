using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            // Método Objet.ToString()
            Console.WriteLine("Olá, mundo!");
            Console.WriteLine(123);
            Console.WriteLine(10.5);
            Console.WriteLine(true);

            object conta = new ContaCorrente(456, 765124);

            string contaToString = conta.ToString();

            Console.WriteLine(conta);
            Console.WriteLine(contaToString);

            Console.ReadKey();


            // Método Objet.Equals()
            Cliente carlos1 = new Cliente();
            carlos1.Nome = "Carlos";
            carlos1.CPF = "458.623.120-03";
            carlos1.Profissao = "Designer";

            Cliente carlos2 = new Cliente();
            carlos2.Nome = "Carlos";
            carlos2.CPF = "458.623.120-03";
            carlos2.Profissao = "Designer";

            if (carlos1.Equals(carlos2))
            {
                Console.WriteLine("São iguais!");
            }
            else
            {
                Console.WriteLine("Não são iguais!");
            }

            ContaCorrente conta2 = new ContaCorrente(2121, 327632);

            if (carlos1.Equals(conta2))
            {
                Console.WriteLine("São iguais!");
            }
            else
            {
                Console.WriteLine("Não são iguais!");
            }

            Console.ReadKey();
        }

        public static void TestaString()
        {
            // Expressões Regulares

            //string padrao = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            //string padrao = "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
            //string padrao = "[0-9]{4}[-][0-9]{4}";
            //string padrao2 = "[0-9]{4,5}[-][0-9]{4}";
            //string padrao3 = "[0-9]{4,5}[-]{0,1}[0-9]{4}";
            //string padrao3 = "[0-9]{4,5}-{0,1}[0-9]{4}";
            string padrao3 = "[0-9]{4,5}-?[0-9]{4}";
            string textoDeTeste = "Meu nome é Luis, me ligue em 92639-3739";

            Match resultado = Regex.Match(textoDeTeste, padrao3);

            Console.WriteLine(Regex.IsMatch(textoDeTeste, padrao3));
            Console.WriteLine(resultado.Value);

            Console.ReadKey();


            // TESTE: pegando valor de parâmetro usando o método GetValor

            string urlParametros = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            ExtratorValorDeArgumentosURL extratorDeValores = new ExtratorValorDeArgumentosURL(urlParametros);

            Console.WriteLine("Valor de moedaOrigem: " + extratorDeValores.GetValor("moedaOrigem"));
            Console.WriteLine("Valor de moedaDestino: " + extratorDeValores.GetValor("moedaDestino"));
            Console.WriteLine("Valor de valor: " + extratorDeValores.GetValor("valor"));
            Console.WriteLine("Valor de Valor: " + extratorDeValores.GetValor("Valor"));

            Console.ReadKey();

            // TESTE: pegando valor de parâmetro

            // pagina?argumentos
            // 012345678...

            string url = "pagina?moedaOrigem=real&moedaDestino=dolar";
            string nomeParametro = "moedaOrigem";
            string valorParametro;

            // Calculando indiceInicial
            int indiceInicial = url.IndexOf(nomeParametro + "=") + nomeParametro.Length + 1;

            // Caulculando o indiceFinal
            int indiceFinal = 0;
            int tamanho = 0;

            indiceFinal = url.IndexOf('&', indiceInicial);
            tamanho = indiceFinal - indiceInicial;

            // Calculando valorParametro
            if (indiceFinal > 0)
            {
                valorParametro = url.Substring(indiceInicial, tamanho);
            }
            else
            {
                valorParametro = url.Substring(indiceInicial);
            }

            Console.WriteLine(indiceInicial);
            Console.WriteLine(indiceFinal);
            Console.WriteLine(valorParametro);

            Console.ReadKey();
        }
    }
}
