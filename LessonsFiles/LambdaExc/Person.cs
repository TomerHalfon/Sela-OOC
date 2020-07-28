namespace LambdaExc
{
    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return "Name: " + Name + " Age: " + Age;
        }
    }
}
