using System.Text;

namespace Personalregister
{
    public class Employee
    {
        private string name;

        private float salary;

        public Employee(string name, float salary)
        {
            this.name = name;
            this.salary = salary;
        }

        override public string ToString()
        {
            return ToTableRow(0);
        }
        public string ToTableRow(int spaceForName = 80)
        {
            StringBuilder sb = new StringBuilder();
            if(spaceForName <= 20)
            {
                sb.Append(name + ", ");
            } else
            {
                sb.Append(name.PadRight(spaceForName));
            }
            sb.Append(salary.ToString("0.00"));
            sb.Append(" kr");
            return sb.ToString();
        }
    }
}