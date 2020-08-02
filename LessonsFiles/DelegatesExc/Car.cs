
namespace DelegatesExc
{
    class Car
    {
        public string Name { get; private set; }
        public int LicencseId { get; private set; }
        public bool IsDirty { get;  set; }
        public int DistanceTravelled { get; private set; }

        public Car(string name, int licencseId)
        {
            Name = name;
            LicencseId = licencseId;
        }
        public void Travel(int distanceKm)
        {
            DistanceTravelled += distanceKm;
        }
    }
}
