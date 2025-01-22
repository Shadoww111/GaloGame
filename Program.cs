class Program()
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.Desenhar();
        menu.Carregamento();
        
        Jogo jogo = new Jogo();
        jogo.Iniciar();
    }

}