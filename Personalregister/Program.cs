

namespace Personalregister
{
    internal class Program
    {

        private Dictionary<int, string> menu = new Dictionary<int, string>()
        {
            {1, "Lägg till anställd"},
            {2, "Visa alla anställda"},
            // {3, "Ta bort anställd"},
            // {4, "Sök anställd"},
            // {5, "Avsluta"}
        };
        static void Main(string[] args)
        {
            Console.WriteLine("Hej! Vad vill du göra idag?");
            bool doRun = true;
            while (doRun)
            {
                PrintMenu();
                int input = GetInput();
                if(input == 0)
                {
                    Console.WriteLine("Tack och hej!");
                    doRun = false;
                } else
                {
                    Console.WriteLine($"Du valde: {new Program().menu[input]}");
                }
            }
        }

        /// <summary>
        /// get user input and validate it
        /// </summary>
        /// <returns>an int that corresponds to a menu item</returns>
        private static int GetInput()
        {
            if(!int.TryParse(Console.ReadLine(), out int input))
            {
                return 0;
            }
            return new Program().menu.ContainsKey(input) ? input : 0;
        }

        private static void PrintMenu()
        {
            foreach (var item in new Program().menu)
            {
                Console.WriteLine($"{item.Key}. {item.Value}");
            }
        }
    }
}
