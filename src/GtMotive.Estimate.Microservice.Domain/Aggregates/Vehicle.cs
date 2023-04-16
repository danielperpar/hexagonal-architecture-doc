#pragma warning disable SA1600

using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Aggregates
{
    public sealed class Vehicle
    {
        public Vehicle(Guid vehicleId, TradeMark tradeMark, Model model, PlateNumber plateNumber, Year fabricationYear, Renter renter = null)
        {
            VehicleId = vehicleId;
            TradeMark = tradeMark;
            Model = model;
            PlateNumber = plateNumber;
            FabricationYear = fabricationYear;
            Renter = renter;
        }

        public Guid VehicleId { get; set; }

        public TradeMark TradeMark { get; set; }

        public Model Model { get; set; }

        public PlateNumber PlateNumber { get; set; }

        public Year FabricationYear { get; set; }

        public Renter Renter { get; set; }
    }
}
