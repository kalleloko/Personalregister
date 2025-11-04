



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
                int input = GetInput();
                if(input == 0)
                {
                    Console.WriteLine("Tack och hej!");
                    doRun = false;
                } else
                {
                    switch (input)
                    {
                        case 1:
                            string name = AskForString("Ange namn: ");
                            float salary = AskForFloat("Ange lön: ");
                            
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
                            int id = AskForInt("Välj nummer på anställd du vill ta bort: \n" + employeeRegister.ToTable());
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

        private static int AskForInt(string question = "")
        {
            if (!string.IsNullOrEmpty(question))
            {
                Console.WriteLine(question);
            }
            int result;
            if (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Ogiltigt värde, försök igen.");
                return AskForInt(question);
            }
            return result;
        }

        private static float AskForFloat(string question = "")
        {
            if(!string.IsNullOrEmpty(question))
            {
                Console.WriteLine(question);
            }
            float result;
            if (!float.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Ogiltigt värde, försök igen.");
                return AskForFloat(question);
            }
            return result;
        }

        private static string AskForString(string question = "")
        {
            if (!string.IsNullOrEmpty(question))
            {
                Console.WriteLine(question);
            }
            return Console.ReadLine() ?? "";
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
            return menu.ContainsKey(input) ? input : 0;
        }

        private static void PrintMenu()
        {
            foreach (var item in menu)
            {
                Console.WriteLine($"{item.Key}. {item.Value}");
            }
        }
    }
}
