
internal class Jogo
{
    public Jogo()
    {
    }

    static int choice;
    private char player = 'X';
    private event Action? Ganhou;
    private event Action? Empatou;

    internal void Iniciar()
    {
        Console.Clear();

        //subscrição da mensagem de vitoria
        this.Ganhou += this.MensagemVitoria;
        this.Empatou += this.MensagemEmpate;

        bool jogoADecorrer = true;
        //Incialização do Tabuleiro
        Tabuleiro tabuleiro = new Tabuleiro();
        Console.WriteLine("Bem-Vindo ao Jogo do Galo!\n");
        tabuleiro.Desenhar();
        while (jogoADecorrer)
        {
            ObterInputDoPlayer();

            // tabuleiro começa em 0 mas na consola começa em 1 entao resposta -= 1
            choice -= 1;

            // se for valido
            if (tabuleiro.JogadaValida(choice))
            {
                //Regista a jogada
                tabuleiro.RegistarJogada(choice, player);
                Console.Clear();
                tabuleiro.Desenhar();

                //Verifica o estado do jogo
                bool vitoria = tabuleiro.VerificarVitoria(player);
                bool empate = tabuleiro.VerificarEmpate();
  
                //Caso seja vitoria ou empate -> jogoADecorrer = !jogoADecorrer
                if (vitoria)
                {
                    jogoADecorrer = false;
                    //mensagem de Vitória
                    //Invoca o evento de vitória
                    Ganhou?.Invoke();
                    Ganhou -= this.MensagemVitoria;
                    break;
                }

                if (empate)
                {
                    jogoADecorrer = false;
                    //Invoca o evento de empate
                    Empatou?.Invoke();
                    Empatou -= this.MensagemEmpate;
                    break;
                }


                //Troca o turno
                this.TrocarTurno();
            }
            else
            {
            
                Console.WriteLine("Jogada Inválida, Tente Novamente!");
            }
        }
    }

    private void ObterInputDoPlayer()
    {
        Console.WriteLine("\nPlayer: " + player);
        Console.Write("R: ");
        choice = int.Parse(Console.ReadLine());
    }

    private void TrocarTurno()
    {
        if (this.player == 'X')
        {
            this.player = 'O';
        }
        else this.player = 'X';
    }
    private void MensagemVitoria()
    {
        Console.WriteLine($"EVENTO: Ganhou o jogador {this.player}");
        return;
    }
    private void MensagemEmpate()
    {
        Console.WriteLine($"EVENTO: Empatou!");
        return;
    }
}