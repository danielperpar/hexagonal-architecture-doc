using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Aggregates
{
    /// <summary>
    /// Vehicle.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="vehicleId">vehicleId.</param>
        /// <param name="tradeMark">tradeMark.</param>
        /// <param name="model">model.</param>
        /// <param name="plateNumber">plateNumber.</param>
        /// <param name="fabricationYear">fabricationYear.</param>
        /// <param name="renter">renter.</param>
        public Vehicle(Guid vehicleId, TradeMark tradeMark, Model model, PlateNumber plateNumber, FabricationYear fabricationYear, Renter renter = null)
        {
            VehicleId = vehicleId;
            TradeMark = tradeMark;
            Model = model;
            PlateNumber = plateNumber;
            FabricationYear = fabricationYear;
            Renter = renter;
        }

        /// <summary>
        /// Gets or sets vehicleId.
        /// </summary>
        public Guid VehicleId { get; set; }

        /// <summary>
        /// Gets or sets tradeMark.
        /// </summary>
        public TradeMark TradeMark { get; set; }

        /// <summary>
        /// Gets or sets model.
        /// </summary>
        public Model Model { get; set; }

        /// <summary>
        /// Gets or sets plateNumber.
        /// </summary>
        public PlateNumber PlateNumber { get; set; }

        /// <summary>
        /// Gets or sets fabricationYear.
        /// </summary>
        public FabricationYear FabricationYear { get; set; }

        /// <summary>
        /// Gets or sets renter.
        /// </summary>
        public Renter Renter { get; set; }
    }
}
