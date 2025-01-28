class Program()
{
     public static void Main()
    {
        Menu menu = new Menu();
        menu.Desenhar();
        menu.Carregamento();
        
        Jogo jogo = new Jogo();
        jogo.Iniciar();
    }

}