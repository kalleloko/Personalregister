
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
            PrintMenu();
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
