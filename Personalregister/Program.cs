
using System.Reflection;


namespace Personalregister
{
    internal class Program
    {

        private static EmployeeRegister employeeRegister = new EmployeeRegister();

        private static Dictionary<int, string> menu = new Dictionary<int, string>()
        {
            {1, "Lägg till anställd"},
            {2, "Visa alla anställda"},
            {3, "Ta bort anställd"},
            // {4, "Sök anställd"},
            {0, "Avsluta"}
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Hej! Vad vill du göra idag?");
            bool doRun = true;
            while (doRun)
            {
                PrintMenu();
                int input = GetMenuInput();
                if(input == 0)
                {
                    Console.WriteLine("Tack och hej!");
                    doRun = false;
                } else
                {
                    switch (input)
                    {
                        case 1:
                            string name = AskForValue<string>("Ange namn: ");
                            float salary = AskForValue<float>("Ange lön: ");
                            
                            Employee employee = employeeRegister.AddEmployee(name, salary);
                            Console.WriteLine("Anställd tillagd: " + employee.ToString());
                            Console.WriteLine("Antal anställda nu: " + employeeRegister.GetEmployeeCount());
                            break;
                        case 2:
                            Console.WriteLine("");
                            Console.WriteLine("Visar företagets " + employeeRegister.GetEmployeeCount() + " anställda:");
                            Console.WriteLine(employeeRegister.ToTable());
                            break;
                        case 3:
                            Console.WriteLine("");
                            int id = AskForValue<int>("Välj nummer på anställd du vill ta bort: \n" + employeeRegister.ToTable());
                            employeeRegister.RemoveEmployee(id-1);
                            Console.WriteLine("Företaget har nu " + employeeRegister.GetEmployeeCount() + " anställda");
                            break;
                        // case 4:
                        //     employeeRegister.SearchEmployee();
                        //     break;
                        default:
                            // input is garantueed to be valid due to GetInput method,
                            // so this should never be reached
                            // but just in case, we can exit the program
                            doRun = false;
                            break;
                            
                    }
                }
                Console.WriteLine();
            }
        }

        private static T AskForValue<T>(string question = "")
        {
            if (!string.IsNullOrEmpty(question))
            {
                Console.WriteLine(question);
            }

            string? input = Console.ReadLine();

            // Specialfall för string
            if (typeof(T) == typeof(string))
            {
                return (T)(object)(input ?? "");
            }

            // Hämta TryParse(string, out T)
            var tryParseMethod = typeof(T).GetMethod(
                "TryParse",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new Type[] { typeof(string), typeof(T).MakeByRefType() },
                null
            );

            if (tryParseMethod == null)
            {
                return default!;
            }

            // Skapa argumentlista för TryParse
            object?[] args = new object?[] { input, null };

            // Anropa metoden: bool success = T.TryParse(input, out value)
            bool success = (bool)tryParseMethod.Invoke(null, args)!;

            if (!success)
            {
                Console.WriteLine("Ogiltigt värde, försök igen.");
                return AskForValue<T>(question);
            }
            return (T)args[1]!; // args[1] innehåller 'out'-resultatet
        }

        /// <summary>
        /// get user input and validate it
        /// </summary>
        /// <returns>an int that corresponds to a menu item</returns>
        private static int GetMenuInput()
        {
            if(!int.TryParse(Console.ReadLine(), out int input))
            {
                return 0;
            }
            return menu.ContainsKey(input) ? input : 0;
        }

        private static void PrintMenu()
        {
            Console.WriteLine("--------------------------");
            foreach (var item in menu)
            {
                Console.WriteLine($"{item.Key}. {item.Value}");
            }
            Console.WriteLine("--------------------------");
        }
    }
}
