using System.Collections.Generic;

namespace DelegatesExc
{
    delegate void CarAction(Car c);

    class Garage
    {
        List<Car> _cars = new List<Car>();
        public void Add(Car car)
        {
            _cars.Add(car);
        }
        public void WashCars()
        {
            foreach (Car car in _cars)
            {
                if (car.IsDirty)
                {
                    car.IsDirty = false;
                }
            }
        }
        public void PerformCustomOperation(CarAction carAction)
        {
            foreach (Car car in _cars)
            {
                carAction.Invoke(car);
            }
        }
    }
}