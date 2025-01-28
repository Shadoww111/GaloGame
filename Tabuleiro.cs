

using System.Numerics;

internal class Tabuleiro
{
    

    public Tabuleiro()
    {
    }
    public char[] tab = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    internal void Desenhar()
    {
        for (int i = 0; i < 9; i++)
        {
       
            if (tab[i] == 'X')
            {
                Console.ForegroundColor = ConsoleColor.Red; 
            }
            else if (tab[i] == 'O')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ResetColor(); 
            }

            Console.Write($" {tab[i]} ");

            // quando o resto da divisao do numero for igual a 2 quer dizer que e o final de uma linha
            if (i % 3 == 2) 
            {
                Console.WriteLine();
                if (i < 8) // < para nao escrever a ultima linha
                {
                    Console.ResetColor();
                    Console.WriteLine("-----------");
                }
            }
            // caso nao seja o final de uma linha a celula sera separada por uma barra |
            else
            {
                Console.ResetColor();
                Console.Write("|");
            }
        }

        Console.ResetColor(); 
    }
    internal void ResetarTabuleiro()
    {
        tab = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    }
    internal bool JogadaValida(int choice)
    {
        if (tab[choice] == 'X' || tab[choice] == 'O')
        {
            return false;
        }
        return true;
        
       
    }

    internal void RegistarJogada(int choice, char player)
    {
        tab[choice] = player;
    }

    internal bool VerificarVitoria(char player)
    {
        if (EspacosPreenchidos() < 5) { return false; }
        //caso seja linha

        //linha 1
        if (tab[0] == tab[1] && tab[1] == tab[2])
        {
            return true;
        }
        //linha 2
        if (tab[3] == tab[4] && tab[4] == tab[5])
        {
            return true;
        }
        //linha 3
        if (tab[6] == tab[7] && tab[7] == tab[8])
        {
            return true;
        }

        // caso seja coluna

        //primeira coluna
        if (tab[0] == tab[3] && tab[3] == tab[6])
        {
            return true;
        }
        //segunda coluna
        if (tab[1] == tab[4] && tab[4] == tab[7])
        {
            return true;
        }
        //terceira coluna
        if (tab[2] == tab[5] && tab[5] == tab[8])
        {
            return true;
        }

        //caso seja diagonal

        //do canto superior esquerdo para o canto inferior direito
        if (tab[0] == tab[4] && tab[4] == tab[8])
        {
            return true;
        }
        if (tab[2] == tab[4] && tab[4] == tab[6])
        {
            return true;
        }
        return false;   
    }

    private int EspacosPreenchidos()
    {
       var espacosPreenchidos = 0;
        foreach (char c in tab)
        {
            if (c == 'X' || c == 'O')
            {
                espacosPreenchidos++;
            }
        }
        return espacosPreenchidos;
    }

    internal bool VerificarEmpate()
    {
        //para ser empate têm q estar todas cheias
        foreach (char c in tab)
        {
            if (c != 'X' && c != 'O')
            {
                return false;
            }
        }
        return true;
    }
}