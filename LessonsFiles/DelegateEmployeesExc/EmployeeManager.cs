using System;
using System.Collections;
using System.Collections.Generic;

namespace DelegateEmployeesExc
{
    delegate int CompareBy(Employee x, Employee y);
    delegate void EmployeeAction(Employee employee);

    class EmployeeManager : IEnumerable<Employee>
    {
        private List<Employee> _employees = new List<Employee>();

        public void Add(Employee emp)
        {
            _employees.Add(emp);
        }

        public void Print()
        {
            foreach (var item in _employees)
            {
                Console.WriteLine(item);
            }
        }
        // show how one can sort elements using simple non efficient sort
        public void Sort(CompareBy compareBy)
        {
            for (int i = 0; i < _employees.Count; i++)
            {
                for (int j = 0; j < _employees.Count - 1; j++)
                {
                    if (compareBy.Invoke(_employees[j], _employees[j + 1]) > 0) 
                    {
                        var tmp = _employees[j];
                        _employees[j] = _employees[j + 1];
                        _employees[j + 1] = tmp;
                    }
                }
            }
        }

        public void ForeachAction(EmployeeAction action)
        {
            foreach (Employee employee in _employees)
            {
                action.Invoke(employee);
            }
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            return _employees.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _employees.GetEnumerator();
        }
#if test
        // show how one can sort elements using simple non efficient sort
        public void SortByName()
        {
            for (int i = 0; i < _employees.Count; i++)
            {
                for (int j = 0; j < _employees.Count - 1; j++)
                {
                    if (_employees[j].Name.CompareTo(_employees[j + 1].Name) == 1)
                    {
                        var tmp = _employees[j];
                        _employees[j] = _employees[j + 1];
                        _employees[j + 1] = tmp;
                    }
                }
            }
        }
#endif
    }
}
