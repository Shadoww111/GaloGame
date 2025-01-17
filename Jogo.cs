
using GaloJogo;

internal class Jogo
{
    const int NR_LINHAS = 3;
    const int NR_COLUNAS = 3;
    internal void Iniciar()
    {
        bool JogoADecorrer = true;
        // Inicialização do tabuleiro
        List<Celula> celulas = new List<Celula>();
        for (int linha = 0; linha < NR_LINHAS;linha++)
        {
            for (int coluna = 0; coluna < NR_COLUNAS; coluna++)
                {
                    celulas.Add(new Celula(linha, coluna, " "));
                    //Console.WriteLine($"Celula: "+ "Linha:" + linha + "Coluna: "+ coluna);
                }
        }
        Tabuleiro tabuleiro = new Tabuleiro(celulas);
        tabuleiro.Desenhar();
        tabuleiro.RegistrarJogada("X", 2, 2);
        tabuleiro.Desenhar();
        Console.WriteLine("Jogo do Galo");
        while (JogoADecorrer) { 
            
        }
    }
}