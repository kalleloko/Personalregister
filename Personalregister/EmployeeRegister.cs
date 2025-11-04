
namespace Personalregister
{
    internal class EmployeeRegister
    {
        public void AddEmployee(Employee employee)
        {
            Console.WriteLine("Anställd tillagd: " + employee.ToString());
        }

        internal void AddEmployee(string name, float salary)
        {
            Employee employee = new Employee(name, salary);
            AddEmployee(employee);
        }

        public override string ToString()
        {
            return "Här skulle alla anställda visas.";
        }
    }
}