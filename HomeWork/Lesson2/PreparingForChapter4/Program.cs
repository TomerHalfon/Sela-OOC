using System;

namespace PreparingForChapter4
{
    class Program
    {
        #region for ease of use only!
        const int AppRecWidth = 20;
        const int AppRecHeight = 10;
        const int AppRecX = 1;
        const int AppRecY = 0;
        private static int RequestNumber(string msg)
        {
            int num;
            Console.Write(msg);
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Invalid input!\nTry again...");
            }
            return num;
        } 
        #endregion
        static void Main()
        {
            //Create a user defiend Rectangle
            Rectangle userRectangle = new Rectangle(
                RequestNumber("Please enter the X position of the rectangle: "),
                RequestNumber("Please enter the Y position of the rectangle: "),
                RequestNumber("Please enter the width of the rectangle: "),
                RequestNumber("Please enter the height of the rectangle: ")
                );

            //print the user rectangle
            Console.WriteLine("\nUser Rectanagle\n" + userRectangle);

            //Create appliacation Rectangle using hard coded data
            Rectangle applicationRectangle = new Rectangle(AppRecX, AppRecY, AppRecWidth, AppRecHeight);

            //print the application rectangle
            Console.WriteLine("Application Rectanagle\n" + applicationRectangle);

            //compare the two using rectangle IsSizeEqual
            Console.WriteLine($"Comparing two Rectangles by size...");
            if (applicationRectangle.IsSizeEqual(userRectangle))
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("not Equal");
            }

            //print the smaller Rectangle
            Console.WriteLine($"The minimal rectangle is {applicationRectangle.Minimum(userRectangle)}");

            //Set app rectangle's data to user rectangle's data
            Console.WriteLine("updating application rectangle to user rectangle data...");
            applicationRectangle.Assign(userRectangle);

            //Compare the two using overriden Equals method(compares data)
            Console.WriteLine($"Comparing two Rectangles using Equals method...");
            if (applicationRectangle.Equals(userRectangle))
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("not Equal");
            }

            //comparing with == (in refrence types compares adress in heap)
            Console.WriteLine("Comparing by adress (==) operator");
            if (applicationRectangle == userRectangle)
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("not Equal");
            }

            //Assign user's rectangle to application rectangle using the (=) operator (assigns adress in heap)
            Console.WriteLine("Assigning user's rectangle to application rectangle using the (=) operator");
            applicationRectangle = userRectangle;

            //conpare the two by adress again (==) now after assigning the adress 
            Console.WriteLine("Comparing by adress (==) operator after the change");
            if (applicationRectangle == userRectangle)
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("not Equal");
            }
        }
    }
}
