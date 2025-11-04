

namespace Personalregister
{
    internal class EmployeeRegister
    {
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public Employee AddEmployee(string name, float salary)
        {
            Employee employee = new Employee(name, salary);
            AddEmployee(employee);
            return employee;
        }

        public override string ToString()
        {
            return "Här skulle alla anställda visas.";
        }

        public int GetEmployeeCount()
        {
            return employees.Count;
        }
    }
}