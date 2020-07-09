
namespace PersonClassExc
{
    class Person
    {
        public int Age { get; private set; }
        public string Name { get; private set; }

        public Person(string name, int age)
        {
            Age = age;
            Name = name;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
        public override bool Equals(object obj)
        {
            bool res = false;
            Person toCompare = (Person)obj;
            if (Name == toCompare.Name&&Age == toCompare.Age)
            {
                res = true;
            }
            return res;
        }
    }
}
