

using System.Numerics;

internal class Tabuleiro
{
    

    public Tabuleiro()
    {
    }
    public char[] arr = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    internal void Desenhar()
    {
        Console.WriteLine("     |     |      ");
        Console.WriteLine($"  {arr[0]}  |  {arr[1]}  |  {arr[2]}");
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine($"  {arr[3]}  |  {arr[4]}  |  {arr[5]}");
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine($"  {arr[6]}  |  {arr[7]}  |  {arr[8]}");
        Console.WriteLine("     |     |      ");
    }

    internal bool JogadaValida(int choice)
    {
        if (arr[choice] == 'X' || arr[choice] == 'O')
        {
            return false;
        }
        return true;
        
       
    }

    internal void RegistarJogada(int choice, char player)
    {
        arr[choice] = player;
    }

    internal bool VerificarVitoria(char player)
    {
        if (EspacosPreenchidos() < 5) { return false; }
        //caso seja linha

        //linha 1
        if (arr[0] == arr[1] && arr[1] == arr[2])
        {
            return true;
        }
        //linha 2
        if (arr[3] == arr[4] && arr[4] == arr[5])
        {
            return true;
        }
        //linha 3
        if (arr[6] == arr[7] && arr[7] == arr[8])
        {
            return true;
        }

        // caso seja coluna

        //primeira coluna
        if (arr[0] == arr[3] && arr[3] == arr[6])
        {
            return true;
        }
        //segunda coluna
        if (arr[1] == arr[4] && arr[4] == arr[7])
        {
            return true;
        }
        //terceira coluna
        if (arr[2] == arr[5] && arr[5] == arr[8])
        {
            return true;
        }

        //caso seja diagonal

        //do canto superior esquerdo para o canto inferior direito
        if (arr[0] == arr[4] && arr[4] == arr[8])
        {
            return true;
        }
        if (arr[2] == arr[4] && arr[4] == arr[6])
        {
            return true;
        }
        return false;   
    }

    private int EspacosPreenchidos()
    {
       var espacosPreenchidos = 0;
        foreach (char c in arr)
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
        foreach (char c in arr)
        {
            if (c != 'X' && c != 'O')
            {
                return false;
            }
        }
        return true;
    }
}