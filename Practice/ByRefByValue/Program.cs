/*Relevent Docs:
 * Passing Reference-Type Parameters : https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/passing-reference-type-parameters
 * Passing Value-Type Parameters : https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/passing-value-type-parameters
 * ref keyword : https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ref
 */
namespace ByRefByValue
{
    class Program
    {
        static void Main(string[] args)
        {
            //int is an example of Value Type
            int a = 11;
            int b = 22;

            //won't change anything
            Swap(a, b);

            //will change the values
            Swap(ref a, ref b);

            //obj is an example of Reference Type
            object obj1 = new object();
            object obj2 = new object();

            //even though we send Reference Type it still operates by value
            Swap(obj1, obj2);

            //now it will change the objects themself (byReference)
            Swap(ref obj1, ref obj2);

        }

        //this function takes two Value Type parameters.
        //so Swap will operate on the two parameters byValue (create duplicate)
        static void Swap (int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        //adding ref keyword will take the adress and work byReference
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        //this swap recives two adress as parameters, it can't change the adress it self, but it can call it's functions
        static void Swap (object obj1, object obj2)
        {
            object temp = obj1;
            obj1 = obj2;
            obj2 = temp;
        }

        //the ref keyword will allow to change the object it self
        static void Swap(ref object obj1, ref object obj2)
        {
            object temp = obj1;
            obj1 = obj2;
            obj2 = temp;
        }

    }
}
