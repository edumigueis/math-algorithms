using System;

class Matematica
{
    int numeroInteiro; // será usado em todas as operações

    public Matematica(int numeroInformado)
    {
        numeroInteiro = numeroInformado;
    }

    public int Multiplicar(int segundoValor)
    {
        int mult = 0;
        while (segundoValor > 0)
        {
            mult += numeroInteiro;  // mult = mult + numeroInteiro;
            segundoValor--;
        }

        // for (int vez=1; vez <= segundoValor; vez++)
        //     mult += numeroInteiro;

        return mult;
    }

    public void Dividir(int segundoValor, out int quociente, out int resto)
    {
        int primeiroValor = numeroInteiro;
        quociente = 0;
        while (primeiroValor >= segundoValor)
        {
            quociente++;
            primeiroValor -= segundoValor;
        }
        resto = primeiroValor;
    }

    public int ConverterBase(int novaBase)
    {
        int valor = numeroInteiro; // para não estragar o valor de numeroInteiro
        string resultado = "";
        while (valor > 0)
        {
            int quociente = valor / novaBase;
            int resto = valor - quociente * novaBase;
            resultado = resto + resultado;  // converte resto para string e o concatena no resultado
            valor = quociente;
        }
        return int.Parse(resultado);
    }

    public double Wallis()
    {
        int sinal = 1;
        var soma = new Somatoria();
        var cont = new Contador(1, numeroInteiro, 1);
        while (cont.Prosseguir())
        {
            double termo = 1.0 / (2 * cont.Valor - 1);
            soma.Somar(sinal * termo);
            sinal = -sinal;
        }
        return soma.Valor;
    }

    public double F(double x)
    {
        int sinal = 1;
        var soma = new Somatoria();
        var cont = new Contador(2, numeroInteiro, 1);
        while (cont.Prosseguir())
        {
            double termo = Math.Pow(x, cont.Valor - 1) / (2 * cont.Valor - 1);
            soma.Somar(sinal * termo);
            sinal = -sinal;
        }
        return soma.Valor;
    }

    public double Fatorial()
    {
        var fat = new Produtorio();
        var vez = new Contador(1, numeroInteiro, 1);
        while (vez.Prosseguir())  // faz a contagem neste método
            fat.Multiplicar(vez.Valor);

        return fat.Valor;
    }

    public string Divisores()
    {
        string lista = ""; // aqui adicionaremos os divisores
        int metade = numeroInteiro / 2;
        var possivelDivisor = new Contador(2, metade, 1);
        while (possivelDivisor.Prosseguir())
        {
            int restoDaDivisao = numeroInteiro %
                                 possivelDivisor.Valor;
            if (restoDaDivisao == 0)
                lista = lista + possivelDivisor.Valor + ", ";
        }
        lista = "1, " + lista + numeroInteiro;
        return lista;
    }


    public bool EhPalindromo()
    {
        int numero = numeroInteiro;
        int aoContrario = 0;        // aux
        while (numero > 0)
        {
            int quociente = numero / 10;
            int resto = numero - 10 * quociente;    // separa dígito
            aoContrario = aoContrario * 10 + resto; // monta ao contrário
            numero = quociente; // o próximo dividendo é o quociente anterior
        }

        if (numeroInteiro == aoContrario)
            return true;
        else
            return false;
        // return numeroInteiro == aoContrario;
    }

    // Exercício 5.31
    public int SomaDosDigitos()
    {
        var umaSoma = new Somatoria();
        int numero = numeroInteiro;
        while (numero > 0)
        {
            int quociente = numero / 10;
            int digito = numero - 10 * quociente; // cálculo do resto da divisão por 10

            umaSoma.Somar(digito);

            numero = quociente;
        }

        return (int)umaSoma.Valor;
    }

    public double Elevado(double a)
    {
        var potencia = new Produtorio();
        var vez = new Contador(1, numeroInteiro, 1);
        while (vez.Prosseguir())
            potencia.Multiplicar(a);

        return potencia.Valor;
    }

    public int SomaDosDivisores()
    {
        var somaDiv = new Somatoria(); // aqui somaremos os divisores
        int metade = numeroInteiro / 2;
        var possivelDivisor = new Contador(2, metade, 1);
        while (possivelDivisor.Prosseguir())
        {
            int restoDaDivisao = numeroInteiro %
                                 possivelDivisor.Valor;
            if (restoDaDivisao == 0)
                somaDiv.Somar(possivelDivisor.Valor);
        }
        somaDiv.Somar(1 + numeroInteiro);
        return (int)somaDiv.Valor;  // (int) converte o tipo para inteiro
    }

    public bool EhPerfeito()
    {
        int somaDiv = SomaDosDivisores();
        return somaDiv == numeroInteiro * 2;
    }

    public bool EhPrimo()
    {
        if (numeroInteiro % 2 == 0)
            if (numeroInteiro == 2)  // 2 é o único primo par
                return true;
            else
                return false;
        else // número ímpar
        {
            var possivelDivisor = new Contador(3, numeroInteiro / 2, 2);
            int resto = 1;
            while (resto != 0 && possivelDivisor.Prosseguir())
            {
                resto = numeroInteiro % possivelDivisor.Valor;
            }

            return (resto != 0);  // se não achamos resto == 0, o número é primo
        }
    }

    public int MMC(int outroValor)
    {
        int A = numeroInteiro;
        int B = outroValor;
        var mmc = new Produtorio();
        var divisor = new Contador(2, int.MaxValue, 1);
        while (A != 1 || B != 1) // condição para a continuação das sucessivas divisões
        {
            int quocA = A / divisor.Valor; 
            int restoA = A - quocA * divisor.Valor;

            int quocB = B / divisor.Valor;
            int restoB = B - quocB * divisor.Valor;
            if (restoA == 0 || restoB == 0)
                mmc.Multiplicar(divisor.Valor);

            if (restoA == 0)
                A = quocA;

            if (restoB == 0)
                B = quocB;

            if (restoA != 0 && restoB != 0)
                divisor.Contar();
        }
        return (int)mmc.Valor; // retornao valor do MMC
    }

    public string Fibonacci()
    {
        int antigoValor = 0; 
        int novoValor = 1; // novo valor, é usado na composição da lista de valores
        int res = 0; // valor resultante calculado à partir da soma de fold e fnew
        string lista = ""; // aqui adicionaremos os valores

        while (res <= numeroInteiro)
        {
            res = antigoValor + novoValor;
            lista = lista + novoValor + ", ";
            antigoValor = novoValor;
            novoValor = res;
        }
        return lista; // retorna a lista de valores de Fibonacci

    }

    public double RaizCubica(double erro)
    {
        int valorDigitado = numeroInteiro;
        double palpite = 1; // primeiro palpite é 1
        double novoPalpite;

        novoPalpite = (valorDigitado / (palpite * palpite) + (2.00 * palpite)) / 3.00;
        Console.WriteLine($"    {palpite}                                   {novoPalpite}");
        palpite = novoPalpite;
        novoPalpite = ((valorDigitado / (palpite * palpite)) + (2.00 * palpite)) / 3.00;
        Console.WriteLine($"    {palpite}                    {novoPalpite}");
        while (palpite - novoPalpite >= erro)
        {
            palpite = novoPalpite;
            novoPalpite = ((valorDigitado / (palpite * palpite)) + (2.00 * palpite)) / 3.00;
            Console.WriteLine($"    {palpite}                    {novoPalpite}");
        }
        return novoPalpite;
    }

    public int CalcularMDC(int outroNumero)
    {
        int soma = 0;
        int A = numeroInteiro; // criação de uma nova variável que receberá a variável global
        int B = outroNumero; // criação de uma nova variável que receberá a variável global
        if (A > B) // cálculo do MDC na condição do primeiro valor digitado for maior
        {
            while (A != B) // condição para continuação da subtração
            {
                soma = A - B;

                A = B;
                B = soma;

                if (soma < 0)
                    B = -soma;
            }
        }
        else
        if (B > A) //cálculo do MDC na condição do segundo valor digitado for maior
        {
            while (B != A) // condição para continuação da subtração
            {
                soma = B - A;

                B = A;
                A = soma;

                if (soma < 0)
                    A = -soma;
            }
        }
        else
        if (A == B) //cálculo do MDC na condição de ambos os valores digitados forem iguais
        {
            soma = A;
        }
        return (int)soma; // retorna o valor do MDC
    }

    public double SinH(double x)
    {
        double fatorial;
        var soma = new Somatoria();
        var cont = new Contador(0, numeroInteiro, 1);
        while (cont.Prosseguir())
        {
            Matematica umValor = new Matematica(2 * cont.Valor + 1);
            fatorial = umValor.Fatorial();
            double termo = (1 / fatorial) * Math.Pow(x, 2 * cont.Valor + 1);
            soma.Somar(termo);
        }
        return soma.Valor;
    }
}
