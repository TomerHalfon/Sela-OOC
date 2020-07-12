namespace TypeClass
{
   public class Person
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

        //get the hash code of the ToString of the obj, becasue we've overriden Equals to compare all of the members
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}