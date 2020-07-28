using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEmployeesExc
{
    class Program
    {
        static void Main()
        {
            EmployeeManager manager = new EmployeeManager();
            manager.Add(new Employee() { Name = "Shlomo", Salary = 7000 });
            manager.Add(new Employee() { Name = "Noam", Salary = 17000 });
            manager.Add(new Employee() { Name = "Yossi", Salary = 5000 });
            manager.Add(new Employee() { Name = "Tomer", Salary = 2000 });

            manager.Print();
        }
    }
}
