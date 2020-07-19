using System;

class Produtorio
{
    double produtorio; // variável global
    int quantosValoresForamMultiplicados; // variável global

    public Produtorio()
    {
        produtorio = 1;
        quantosValoresForamMultiplicados = 0;
    }
    public void Multiplicar(double valorASerMultiplicado)
    {
        produtorio *= valorASerMultiplicado;  // acumula produtos
        quantosValoresForamMultiplicados++;   // conta número de produtos
    }

    public double MediaGeometrica()
    {
        if (quantosValoresForamMultiplicados == 0)
            throw new Exception("Nenhum valor foi multiplicado ainda!");

        // raiz n-ésima do produtório
        return Math.Pow(produtorio, 1.0 / quantosValoresForamMultiplicados);
    }

    public double Valor  // retorna o valor atual do produto acumulado
    {
        get => produtorio;
    }
}



