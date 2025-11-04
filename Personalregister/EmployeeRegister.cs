

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

        public string ToTable()
        {
            StringBuilder sb = new StringBuilder();
            int row = 1;
            foreach (Employee emp in employees) {   
                sb.Append(row + ". " + emp.ToTableRow() + "\n");
                row++;
            }
            return sb.ToString();
        }

        public int GetEmployeeCount()
        {
            return employees.Count;
        }

        public void RemoveEmployee(int id)
        {
            if (id >= 0 && id < employees.Count)
            {
                employees.RemoveAt(id);
            }
        }
    }
}