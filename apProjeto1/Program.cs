using System;
using static System.Console;
using static Utilitarios;
using System.IO;

namespace apProjeto1
{
    class Program
    {
        const int inicioV = 0; // variável global
        const int tamanhoV = 8; // variável global
        const int inicioP = inicioV + tamanhoV; // variável global 
        const int tamanhoP = 8; // variável global
        static double V, P; // variável global
        static double x; // variável global 
        static int numeroInteiro; // variável global
        static int outroNumero; // variável global

        static void ExibirOpcoes() // componente do "seletor de opções"
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkCyan;
            WritePos(10, 1, "==========================");
            WritePos(10, 2, "      Menu de Opções    ");
            WritePos(10, 3, "==========================");

            WritePos(10, 6, "1 - Estatística de uma lista de valores lidos de um arquivo texto");
            WritePos(10, 7, "2 - MMC entre dois valores digitados");
            WritePos(10, 8, "3 - Raiz cúbica de um valor digitado");
            WritePos(10, 9, "4 - MDC por subtrações sucessivas");
            WritePos(10, 10, "5 - Lista de números de Fibonacci");
            WritePos(10, 11, "6 - Seno Hiperbólico");

            WritePos(10, 21, "99 - Terminar programa");
            WritePos(10, 20, "Digite a opção desejada: ");
        }

        static void SeletorDeOpcoes() // outro componente do "seletor de opções"
        {
            int opcao = 0;
            do
            {
                ExibirOpcoes();
                opcao = int.Parse(ReadLine());
                switch (opcao)
                {
                    case 1: CalcularTudo(); break;
                    case 2: MMC(); break;
                    case 3: RaizCubica(); break;
                    case 4: CalcularMDC(); break;
                    case 5: Fibonacci(); break;
                    case 6: CalcularSinH(); break;
                }
            }
            while (opcao != 99);
        }

        static void CalcularTudo()
        {
            LerArquivo();
        }
        static void LerArquivo()
        {
            int N = 0;
            double result = 0, result2 = 0;

            Clear();
            ForegroundColor = ConsoleColor.DarkCyan;
            WritePos(5, 1, "=============================================================================");
            WritePos(5, 2, "        Estatística de uma lista de valores lidos de um arquivo texto     ");
            WritePos(5, 3, "=============================================================================");
            WritePos(8, 7, "Por favor digite o nome do arquivo desejado: ");
            string arquivo = ReadLine();

            var soma = new Somatoria();
            var leitor = new StreamReader(arquivo);
            var produto = new Produtorio();

            while (!leitor.EndOfStream) // leitura de cada linha e chamada de cálculos sobre estas
            {
                string linha = leitor.ReadLine();
                V = Convert.ToDouble(linha.Substring(inicioV, tamanhoV));
                P = Convert.ToDouble(linha.Substring(inicioP, tamanhoP));

                soma.Somar(V + P);
                produto.Multiplicar(V + P);
                soma.SomarComPeso(V, int.Parse(P + ""));
                soma.SomarInversos(V + P);

            }

            leitor.Close();

            double mediaAritmeticaCalculada = soma.MediaAritmetica();
            double mediaGeometricaCalculada = produto.MediaGeometrica();
            double raizMediaQuadraticaCalculada = soma.RaizMediaQuadratica();
            double mediaPonderadaCalculada = soma.MediaPonderada();
            double mediaHarmonicaCalculada = soma.MediaHarmonica();
            WritePos(8, 12, $"O valor da média aritmética é " + mediaAritmeticaCalculada); //exibição de resultados
            WritePos(8, 14, $"O valor da média geométrica é " + mediaGeometricaCalculada);//exibição de resultados
            WritePos(8, 16, $"O valor da raiz média quadrática é " + raizMediaQuadraticaCalculada);//exibição de resultados
            WritePos(8, 18, $"O valor da média ponderada é " + mediaPonderadaCalculada);//exibição de resultados
            WritePos(8, 20, $"O valor da média harmônica é " + mediaHarmonicaCalculada);//exibição de resultados
            WritePos(8, 25, "Pressione [Enter] para prosseguir");
            ReadLine();
        }

        static void MMC()
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkCyan;
            WritePos(5, 1, "=======================================");
            WritePos(5, 2, "    MMC Entre Dois Valores Digitado   ");
            WritePos(5, 3, "=======================================");
            WritePos(2, 7,"Digite o primeiro valor para o MMC:");
            int primeiroValor = int.Parse(ReadLine());
            WritePos(2, 8, "Digite o segundo valor para o MMC:");
            int segundoValor = int.Parse(ReadLine());

            var meuMat = new Matematica(primeiroValor);
            int oMMC = meuMat.MMC(segundoValor);
            WritePos(2, 10, $"0 MMC de {primeiroValor} e {segundoValor} vale {oMMC}.");
            ReadLine();
        }

        static void CalcularMDC()
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkCyan;
            WritePos(5, 1, "=======================================");
            WritePos(5, 2, "     MDC por subtrações sucessivas     ");
            WritePos(5, 3, "=======================================");

            WritePos(8, 7, "Digite o primeiro número inteiro: ");
            numeroInteiro = int.Parse(ReadLine());

            WritePos(8, 9, "Digite o segundo número inteiro: ");
            outroNumero = int.Parse(ReadLine());

            var meuMat = new Matematica(numeroInteiro);
            int oMDC = meuMat.CalcularMDC(outroNumero);
            WritePos(8, 12, $"O MDC({numeroInteiro},{outroNumero}) vale {oMDC}");
            WritePos(8, 25, "Pressione [Enter] para prosseguir");
            ReadLine();
        }

        static void RaizCubica()
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkCyan;
            WritePos(5, 1, "=======================================");
            WritePos(5, 2, "    Raiz Cúbica de um Valor Digitado   ");
            WritePos(5, 3, "=======================================");
            WritePos(2, 7, "Digite o valor do qual deseja calcular a raiz cúbica: ");
            int valorDigitado = int.Parse(ReadLine());
            WritePos(2, 8, "Digite a margem de erro: ");
            double erro = double.Parse(ReadLine());
            var meuMat = new Matematica(valorDigitado);
            WriteLine("\n    Palpite                             Novo valor");
            double aRaiz = meuMat.RaizCubica(erro);
            WriteLine($"\n  A raiz cúbica de {valorDigitado} é aproximadamente {aRaiz}");
            WritePos(2, 25, "Pressione [Enter] para prosseguir");
            ReadLine();
        }

        static void Fibonacci()
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkCyan;
            WritePos(5, 1, "=======================================");
            WritePos(5, 2, "   Valores da Sequência de Fibonacci   ");
            WritePos(5, 3, "=======================================");
            WritePos(8, 7, "Digite o valor até o qual deseja listar a sequência de Fiboncci:");
            int primeiroValor = int.Parse(ReadLine());

            var meuMat = new Matematica(primeiroValor);
            string lista = meuMat.Fibonacci();
            WritePos(8, 12, $"{lista}");
            ReadLine();
        }

        static void CalcularSinH() // exibição ao usuário da operação de conversão
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkCyan;
            WritePos(5, 1, "=======================================");
            WritePos(5, 2, "           Seno Hiperbólico     ");
            WritePos(5, 3, "=======================================");

            WritePos(8, 7, "Digite o número de termos: ");
            numeroInteiro = int.Parse(ReadLine());

            WritePos(8, 9, "Digite o ângulo real(em radianos): ");
            x = double.Parse(ReadLine());

            var meuMat = new Matematica(numeroInteiro);
            double fDeX = meuMat.SinH(x);
            WritePos(8, 12, $"O seno hiperbólico de {x} rad vale {fDeX}");
            WritePos(8, 25, "Pressione [Enter] para prosseguir");
            ReadLine();
        }

        static void Main(string[] args)
        {
            SeletorDeOpcoes();
        }
    }
}
