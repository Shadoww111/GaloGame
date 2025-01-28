
internal class Jogo
{
    public Jogo()
    {
    }

    static int choice;
    private char player = 'X';
    private int PontuaçãodoX = 0;
    private int PontuaçãodoO = 0;
    private event Action? Ganhou;
    private event Action? Empatou;
    private event Action? Score;

    internal void Iniciar()
    {
        bool ContinuePlaying = true;

        while (ContinuePlaying)
        {
            Console.Clear();

            //subscrição da mensagem de vitoria
            this.Ganhou += this.MensagemVitoria;
            this.Empatou += this.MensagemEmpate;
            this.Score += this.MensagemScore;

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
                        if (player == 'X')
                            PontuaçãodoX++;
                        else PontuaçãodoO++;

                        //mensagem de Vitória
                        //Invoca o evento de vitória
                        Ganhou?.Invoke();
                        Ganhou -= this.MensagemVitoria;
                        Score?.Invoke();
                        Score -= this.MensagemScore;
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
            ContinuePlaying = JogarNovamente();

            // Resetar o tabuleiro para o estado inicial após cada jogo
            tabuleiro.ResetarTabuleiro();
        }
        Console.WriteLine("\nObrigado por jogar!");
    }

    private void MensagemScore()
    {
        Console.WriteLine("\nPontuação: ");
        Console.WriteLine("X - " + PontuaçãodoX);
        Console.WriteLine("O - " + PontuaçãodoO);
    }

    private bool JogarNovamente()
    {
        Console.Write("\nDeseja jogar novamente? (S/N)\nR: ");
        string resposta = Console.ReadLine()?.ToUpper();
        if (resposta == "S") return true;
        else return false;
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
        Console.WriteLine($"\nEVENTO: Ganhou o jogador {this.player}");
        return;
    }
    private void MensagemEmpate()
    {
        Console.WriteLine($"\nEVENTO: Empatou!");
        return;
    }
}