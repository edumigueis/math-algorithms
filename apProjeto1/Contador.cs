using System;

  class Contador
  {
    protected int 
      cont,           // atributo que armazena o valor atual da contagem
      valorInicial, 
      valorFinal, 
      passo;

    bool primeiraRepeticao;
    public Contador(int vI, int vF, int incremento)
    {
      cont = valorInicial = vI;
      valorFinal = vF;
      passo = incremento;
      primeiraRepeticao = true;
    }

    public void Iniciar()
    {
      cont = valorInicial;
      primeiraRepeticao = true;
    }

    public void Contar()
    {
      cont += passo;
    }
    public bool Prosseguir()
    {
        if (primeiraRepeticao)
          primeiraRepeticao = false;
        else
          cont += passo;   // cont = cont + passo;

        return cont <= valorFinal;
    }

    public int Valor // propriedade que permite ao programa "ler" o valor de cont
    {
      get => cont;
    }

    public override string ToString()
    {
      return cont+"";
    }
  }
