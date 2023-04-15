using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Dtos
{
    /// <summary>
    /// Vehicle to be rented.
    /// </summary>
    public class VehicleDto
    {
        public VehicleDto(Guid vehicleId, string tradeMark, string model, string plateNumber, DateTime fabricationDate, RenterDto renter = null)
        {
            VehicleId = vehicleId;
            TradeMark = tradeMark;
            Model = model;
            PlateNumber = plateNumber;
            FabricationDate = fabricationDate;
            Renter = renter;
        }

        public Guid VehicleId { get; set; }

        public string TradeMark { get; set; }

        public string Model { get; set; }

        public string PlateNumber { get; set; }

        public DateTime FabricationDate { get; set; }

        public RenterDto Renter { get; set; }
    }
}
