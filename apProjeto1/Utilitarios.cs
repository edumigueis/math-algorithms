using System;
using static System.Console;

static class Utilitarios
{
  static public void WritePos(int coluna, int linha, string texto)
  {
    SetCursorPosition(coluna, linha);
    Write(texto);
  }
  static public void EsperarEnter()
  {
    WritePos(0, 23, "Pressione [Enter] para prosseguir: ");
    ReadLine();
  }
}

