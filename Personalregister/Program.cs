


namespace Personalregister
{
    internal class Program
    {

        private static EmployeeRegister employeeRegister = new EmployeeRegister();

        private static Dictionary<int, string> menu = new Dictionary<int, string>()
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
                    switch (input)
                    {
                        case 1:
                            string name = AskForString("Ange namn: ");
                            float salary = AskForFloat("Ange lön: ");
                            
                            employeeRegister.AddEmployee(name, salary);
                            break;
                        case 2:
                            Console.WriteLine(employeeRegister.ToString());
                            break;
                            // case 3:
                            //     employeeRegister.RemoveEmployee();
                            //     break;
                            // case 4:
                            //     employeeRegister.SearchEmployee();
                            //     break;
                    }
                }
                Console.WriteLine();
            }
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
