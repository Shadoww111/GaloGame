
internal class Menu
{
    private string[] RainbowColors = {
            ConsoleColor.Red.ToString(),
            ConsoleColor.DarkYellow.ToString(),
            ConsoleColor.Yellow.ToString(),
            ConsoleColor.Green.ToString(),
            ConsoleColor.Cyan.ToString(),
            ConsoleColor.Blue.ToString(),
            ConsoleColor.Magenta.ToString()
        };
    private string MenuAscii = @"
   _____       _          _____                      
  / ____|     | |        / ____|                     
 | |  __  __ _| | ___   | |  __  __ _ _ __ ___   ___ 
 | | |_ |/ _` | |/ _ \  | | |_ |/ _` | '_ ` _ \ / _ \
 | |__| | (_| | | (_) | | |__| | (_| | | | | | |  __/
  \_____|\__,_|_|\___/   \_____|\__,_|_| |_| |_|\___|
                                                     
";

    internal void Carregamento()
    {
        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), RainbowColors[0]);
        Console.WriteLine("A carregar...");

        // Definir o comprimento total da barra de carregamento
        int total = 50; // A quantidade de caracteres da barra

        // Exibir a barra de carregamento
        for (int i = 0; i <= total; i++)
        {
            // Calcular a quantidade de preenchimento
            string progress = new string('#', i);
            string remaining = new string('-', total - i);

            // Atualizar a barra na mesma linha
            Console.CursorLeft = 0; // Voltar para o início da linha
            Console.Write($"[{progress}{remaining}] {i * 2}%");

            // Atraso para simular o progresso
            Thread.Sleep(100);
        }
        Console.ForegroundColor = ConsoleColor.White;
    }

    internal void Desenhar()
    {
        string[] lines = MenuAscii.Split('\n');
        int colorIndex = 0;

        foreach (string line in lines)
        {
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), RainbowColors[colorIndex % RainbowColors.Length]);
            Console.WriteLine(line);
            colorIndex++;
        }

        // Reset to default color after printing
        Console.ResetColor();
        
    }
}