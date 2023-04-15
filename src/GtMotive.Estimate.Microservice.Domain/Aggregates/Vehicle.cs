#pragma warning disable SA1600

using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Aggregates
{
    public sealed class Vehicle
    {
        public Guid VehicleId { get; set; }

        public TradeMark TradeMark { get; set; }

        public Model Model { get; set; }

        public PlateNumber PlateNumber { get; set; }

        public DateTime FabricationDate { get; set; }

        public Renter Renter { get; set; }
    }
}
