#pragma warning disable SA1600
#pragma warning disable CA1024

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GtMotive.Estimate.Microservice.Domain.Aggregates
{
    public sealed class Fleet
    {
        private readonly IList<Vehicle> _vehicles;

        public Fleet()
        {
            _vehicles = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public IReadOnlyCollection<Vehicle> GetVehicles()
        {
            return new ReadOnlyCollection<Vehicle>(_vehicles);
        }
    }
}
