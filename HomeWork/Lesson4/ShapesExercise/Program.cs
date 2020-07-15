using ShapesExercise.Classes;
using System;
using System.Windows;

namespace ShapesExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the Shapes
            Rectangle r = new Rectangle(new Point(1.2, 3.3), 10, 5);
            Circle c = new Circle(new Point(15, 5), 10);

            //print the shapes
            Console.WriteLine(r.Print());
            Console.WriteLine(c.Print());

            //resize the shapes
            Console.WriteLine("Resizing the rectangle by 50%...");
            r.Resize(0.5);
            Console.WriteLine("Resizing the Circle by 20%...\n");
            c.Resize(0.2);

            //print the shapes
            Console.WriteLine(r.Print());
            Console.WriteLine(c.Print());

            //move the shapes
            Console.WriteLine("Moving the Rectangle by 20 in the x axis...");
            r.Move(20);
            Console.WriteLine("Moving the Circle by 20 in both axis...");
            c.Move(20,20);

            Console.WriteLine($"\n{r}");
            Console.WriteLine(c);
        }
    }
}
