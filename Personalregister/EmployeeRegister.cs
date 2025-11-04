

using System.Text;

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
            StringBuilder sb = new StringBuilder();
            foreach (Employee emp in employees) {
                sb.Append(emp.ToTableRow() + "\n");
            }
            return sb.ToString();
        }

        public int GetEmployeeCount()
        {
            return employees.Count;
        }
    }
}