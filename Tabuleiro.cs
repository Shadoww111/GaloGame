using GaloJogo;


internal class Tabuleiro
{
    const int NR_LINHAS = 3;
    const int NR_COLUNAS = 3;

    public List<Celula> Celulas = [];
    public Tabuleiro(List<Celula> celulas) { 
        Celulas = celulas;

    }
    public bool VerificarEmpate()
    {
        //para ser empate as celulass tem q tar todas cheias
        foreach (var celula in Celulas)
        {
            if (celula.Valor == " ") return false;
        }
          return true;
        
    }

    //public bool VerificarVitoria()
    //{
    //    //caso seja linha ou colunas
    //    if (Celulas[])
    //    {
    //        return true;
    //    }
    //    //caso seja diagonais
    //    if ()
    //    {
    //        return true;
    //    }
    //}
    public void Desenhar()
    {
        
        for (int linhas = 0; linhas < NR_LINHAS; linhas++)
        {
            for (int colunas = 0;colunas < NR_COLUNAS; colunas++)
            {
                Console.Write($"| {Celulas[linhas * NR_COLUNAS + colunas].Valor}");
            }
            Console.WriteLine("|");
            // fim da linha
            if (linhas < NR_LINHAS - 1) {
                Console.WriteLine("----------");
            }
        }
    }
    public void RegistrarJogada(string valor,int linha, int coluna)
    {
        Celulas.Find(c=> (c.Linha == linha && c.Coluna == coluna)).Valor= valor;
    }
}