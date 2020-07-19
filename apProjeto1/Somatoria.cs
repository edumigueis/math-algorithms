using System;

public class Somatoria
{
    static double somaDePesos, somaPonderada, soma, somaHarmomica; // variável global
    static int numeroInteiro; // variável global
    static int quantosValoresInversosoForamSomados; // variável global
    static int quantosValoresForamSomados; // variável global
    public Somatoria()
    {
        soma = quantosValoresForamSomados = 0;
    }

    public double Valor // retorna o valor atual da soma acumulada
    {
        get => soma;
    }
    public void Somar(double valorASerSomado)
    {
        soma += valorASerSomado;        // acumula na soma o valor passado como parâmetro
        quantosValoresForamSomados++;   // conta a quantidade de valores já somados
    }

    public double MediaAritmetica()  // retorna o valor da média aritmética dos valores passados pelo usuário
    {
        if (quantosValoresForamSomados > 0)
            return soma / quantosValoresForamSomados;

        throw new Exception("Divisão por zero");
    }
    public double RaizMediaQuadratica() // retorna o valor da raiz média quadrática dos valores passados pelo usuário
    {
        return Math.Sqrt(MediaAritmetica());
    }
    public void SomarComPeso(double valor, int peso)
    {
        somaPonderada += (valor * peso);  // acumula na "somaPonderada" o valor da expressão "(valor * peso)"
        somaDePesos += peso; // acumula na "somaDePesos" a soma dos pesos
    }
    public double MediaPonderada()  // retorna o valor da média ponderada dos valores passados pelo usuário 
    {
        return somaPonderada / somaDePesos;
    }
    public void SomarInversos(double valor)
    {
        somaHarmomica += 1 / valor; // acumula na "somaHarmomica" o valor da soma finita de 1/v1 + 1/v2 ... 1/vn
        quantosValoresInversosoForamSomados++; // acumula nesta variável a quantidade de valores somados
    }
    public double MediaHarmonica() // retorna o valor da média harmônica dos valores passados pelo usuário 
    {
        return quantosValoresInversosoForamSomados / somaHarmomica;
    }
}

