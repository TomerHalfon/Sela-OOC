//Docs:
// Delegate Class: https://docs.microsoft.com/en-us/dotnet/api/system.delegate?view=netcore-3.1
// MulticastDelegate Class: https://docs.microsoft.com/en-us/dotnet/api/system.multicastdelegate?view=netcore-3.1
// Delegate Guide: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/
using System;


namespace DelegatesExc
{
    class Program
    {
        /*Functions*/
        static void PrintCarName(Car c)
        {
            Console.WriteLine("Name: " + c.Name);
        }
        static void PrintCarDistance(Car c)
        {
            Console.WriteLine("Distance: " + c.DistanceTravelled);
        }
        static void PrintCarLicencse(Car c)
        {
            Console.WriteLine("Licencse: " + c.LicencseId);
        }
        static void PrintCarDirty(Car c)
        {
            Console.Write("The Car is ");
            Console.WriteLine(c.IsDirty ? "Dirty" : "Clean");
        }

        static void Main()
        {
            //Test Data
            Garage garage = new Garage();
            garage.Add(new Car("Car 1", 1));
            garage.Add(new Car("Car 2", 2));
            garage.Add(new Car("Car 3", 3));
            garage.Add(new Car("Car 4", 4));

            //Anonymous decleration
            garage.PerformCustomOperation(delegate (Car car) { car.Travel(10); });
            //lambada
            garage.PerformCustomOperation((c) => c.IsDirty = (c.LicencseId % 2 == 0) ? true : false);

            //Declare Car Action delegate
            CarAction printCarInfo = new CarAction(PrintCarName);

            //Add a method to the delegate invoke list
            printCarInfo += PrintCarLicencse;
            printCarInfo += PrintCarDistance;
            printCarInfo += PrintCarDirty;

            //calla method that takes a delegate (will invoke all of the methods in the invoking list)
            garage.PerformCustomOperation(printCarInfo);
        }
    }
}