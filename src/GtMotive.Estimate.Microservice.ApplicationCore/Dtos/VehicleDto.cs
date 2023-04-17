using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Dtos
{
    /// <summary>
    /// Vehicle to be rented.
    /// </summary>
    public class VehicleDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleDto"/> class.
        /// </summary>
        /// <param name="vehicleId">Vehicle Id.</param>
        /// <param name="tradeMark">Vehicle tradeMark.</param>
        /// <param name="model">Vehicle model.</param>
        /// <param name="plateNumber">Vehicle plateNumber.</param>
        /// <param name="fabricationYear">Vehicle fabrication year.</param>
        /// <param name="renter">Vehicle renter.</param>
        public VehicleDto(Guid vehicleId, string tradeMark, string model, string plateNumber, string fabricationYear, RenterDto renter = null)
        {
            VehicleId = vehicleId;
            TradeMark = tradeMark;
            Model = model;
            PlateNumber = plateNumber;
            FabricationYear = fabricationYear;
            Renter = renter;
        }

        /// <summary>
        /// Gets or sets the vehicle Id.
        /// </summary>
        [Required]
        public Guid VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the trade mark.
        /// </summary>
        [Required]
        public string TradeMark { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        [Required]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the plate number.
        /// </summary>
        [Required]
        public string PlateNumber { get; set; }

        /// <summary>
        /// Gets or sets the fabrication year.
        /// </summary>
        [Required]
        public string FabricationYear { get; set; }

        /// <summary>
        /// Gets or sets the vehicle renter.
        /// </summary>
        public RenterDto Renter { get; set; }
    }
}
