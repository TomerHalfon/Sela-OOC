//Docs:
// Delegate Class: https://docs.microsoft.com/en-us/dotnet/api/system.delegate?view=netcore-3.1
// MulticastDelegate Class: https://docs.microsoft.com/en-us/dotnet/api/system.multicastdelegate?view=netcore-3.1
// Delegate Guide: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/
using System;


namespace DelegateEmployeesExc
{
    class Program
    {
        static int CompareBySalary(Employee x, Employee y)
        {
            return x.Salary.CompareTo(y.Salary);
        }
        static void Main()
        {
            EmployeeManager manager = new EmployeeManager();
            manager.Add(new Employee() { Name = "Shlomo", Salary = 7000  });
            manager.Add(new Employee() { Name = "Noam"  , Salary = 17000 });
            manager.Add(new Employee() { Name = "Yossi" , Salary = 5000  });
            manager.Add(new Employee() { Name = "Tomer" , Salary = 2000  });

            Console.WriteLine("Data");
            manager.Print();
            Console.WriteLine("\nSorting...");
            
            //using lambada
            manager.Sort((x, y) => { return x.Salary.CompareTo(y.Salary); });
            manager.Print();
            Console.WriteLine("\nSorting...");

            //using anonymous decleration
            manager.Sort(delegate(Employee x, Employee y) { return x.Name.CompareTo(y.Name);});
            manager.Print();
            Console.WriteLine("\nSorting...");

            //using a declared function
            CompareBy compare = new CompareBy(CompareBySalary);
            manager.Sort(compare);
            manager.Print();
        }
    }
}