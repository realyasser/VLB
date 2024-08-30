namespace VLN
{
    internal class Program
    {

        static void Title() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("___      ___ ___       ________      ");
            Console.WriteLine("|\\  \\    /  /|\\  \\     |\\   __  \\    ");
            Console.WriteLine("\\ \\  \\  /  / | \\  \\    \\ \\  \\|\\ /_   ");
            Console.WriteLine(" \\ \\  \\/  / / \\ \\  \\    \\ \\   __  \\  ");
            Console.WriteLine("  \\ \\    / /   \\ \\  \\____\\ \\  \\|\\  \\ ");
            Console.WriteLine("   \\ \\__/ /     \\ \\_______\\ \\_______\\");
            Console.WriteLine("    \\|__|/       \\|_______|\\|_______|");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("        [Vanity Links Breaker]         ");
            Console.WriteLine("\n");
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Title();
            if(args.Length > 0) {
                VanityBreaker.FindOrigin(args[0]);
            } else {
                while (true) {

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("$ ");

                    Console.ForegroundColor = ConsoleColor.White;
                    string link = Console.ReadLine();

                    if (link == "") continue;

                    VanityBreaker.FindOrigin(link);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\nPress any key to continue....");
                    Console.ReadKey();
                    Console.Clear();
                    Title();
                }
            }
            Console.ResetColor();
        }
    }
}
