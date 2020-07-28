namespace DelegateEmployeesExc
{
    class Employee
    {
        public string Name { get; set; }
        public float Salary { get; set; }

        public override string ToString()
        {
            return string.Format("Name {0}, Salary {1}", Name, Salary);
        }
    }
}
