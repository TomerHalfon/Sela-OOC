using PersonClassExc.Enums;

namespace PersonClassExc
{
    class Person
    {
        // PersonCount is a static property that holds a counter that we add to when we call the full constructor
        //(there's no need to initialize it in a separate static constructor, since there is no logic needed)
        public static int PersonCount { get; private set; } = 0;

        //Id property can't be changed at all(can only be initialized), not even from within the class
        //(readonly properties are a C#8 feature so we can't use them in .NET framework).
        public int Id { get; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Months BirthMonth { get; private set; }

        //Full constructor with a default age value
        public Person(string name,Months birthMonth ,int age = 30)
        {
            Name = name;
            Age = age;
            BirthMonth = birthMonth;

            //increase the counter 
            ++PersonCount;

            //assign an Id
            Id = PersonCount;
        }
        //A constructor that calls a diffrent constructor with valuse from the user of the class and from the class logic
        //public Person(string name) : this(name, 30) { }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Age: {Age}, Born in {BirthMonth}";
        }
        
        public override bool Equals(object obj)
        {
            //create a res variable and assign it as false
            bool res = false;

            //if the type of obj(we get it with the GetType() method) is the same type as Class Person
            //(we do this using the typeof(insert name of Object here) operator)
            if (obj.GetType() == typeof(Person))
            {
                //now that we're sure that obj is of type Person, we can safely DownCast(using (Person))
                Person toCompare = (Person)obj;

                //comparing the properties of the two objects 
                if (Name == toCompare.Name && Age == toCompare.Age)
                {
                    res = true;
                }
            }

            //if the types don't match(therefore they can't be equal and so we can skip some processing)
            //return false if res wasn't changed
            return res;
        }
        public override int GetHashCode()
        {
            //since our equal condition is coparing only the Name and the Age properties. we dont care about the Id
            return $"{Name}{Age}".GetHashCode();
        }
    }
}
