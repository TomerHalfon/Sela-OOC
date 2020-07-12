
namespace PersonClassExc
{
    class Person
    {
        // personCount is a static property that holds a counter that we add to when we call the full constructor
        //(there's no need to initialize it in a separate static constructor, since there is no logic needed)
        public static int personCount { get; private set; } = 0;
        //Id proerty canot be changed at all, not even from within the class.
        //it gets the data only when we initialize a new instance of this class
        public int Id { get; } = personCount;
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;

            //increase the counter 
            ++personCount;
        }

        //Gets only the name parameter and passes a hard coded age to the full constructor
        public Person(string name) : this(name, 30) { }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Age: {Age}";
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
    }
}
