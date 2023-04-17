using System;
using System.Collections.Generic;
using System.Globalization;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetVehicles;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore.TestData
{
    public static class GetVehiclesTestData
    {
        public static IEnumerable<Vehicle> GetVehicles()
        {
            var vehicles = new List<Vehicle>();

            var vehicle1 = new Vehicle(
                Guid.NewGuid(),
                new TradeMark("vw"),
                new Model("polo"),
                new PlateNumber("b12345h"),
                new FabricationYear(DateTime.Now.Year.ToString(new CultureInfo("es-ES"))));

            var vehicle2 = new Vehicle(
                Guid.NewGuid(),
                new TradeMark("ford"),
                new Model("focus"),
                new PlateNumber("b34567h"),
                new FabricationYear(DateTime.Now.Year.ToString(new CultureInfo("es-ES"))));

            vehicles.Add(vehicle1);
            vehicles.Add(vehicle2);

            return vehicles;
        }

        public static GetVehiclesInput Input()
        {
            return new GetVehiclesInput();
        }
    }
}
