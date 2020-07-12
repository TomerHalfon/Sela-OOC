using System;

namespace TypeClass
{
    class Program
    {
        static void Main(string[] args)
        {
            //create any class (Person in this case)
            Person p1 = new Person("Person", 26);
            Person p2 = new Person("Person", 26);

            //p1 and p2 are both Person Class objects, so they share the same Type variable which they automaticly get
            Type t1 = p1.GetType();
            Type t2 = p2.GetType();
            
            if (t1 == t2)
            {
                Console.WriteLine("They have the same adress in the heap\n");
            }

            //Type class contains all of the information about the Person Class. for example:
            //the name of the class
            Console.WriteLine($"The Name of the type: {t1.Name}");
            //the dll information
            Console.WriteLine($"The dll in which Class Person is at is: {t1.Assembly}");
            //is it public
            Console.WriteLine($"Is the type public?: {t1.IsPublic}\n");
            //and many more...

            //where is it usefull?
            //for example:
            //it is VERY dangerous to (cast) any object, 
            //because it's possible to use objects which are the derived class and store them in the base format.
            //for example
            object obj = new Book("Book", 150);

            //this code is bad and will cause an Exaption
            //Person p3 = (Person)obj;

            //Therefore it's a best practice to verify it's type before you DownCast(cast)
            if (obj.GetType() == typeof(Person))
            {
                //only now we can DownCast
                Person p3 = (Person)obj;
            }

            //use the Equals method
            Console.WriteLine($"is p1 Equals to obj? {p1.Equals(obj)}");
            Console.WriteLine($"is p1 Equals to p2? {p1.Equals(p2)}\n");
        }
    }
}