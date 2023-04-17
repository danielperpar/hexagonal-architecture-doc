using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Dtos
{
    /// <summary>
    /// Request class for the rent vehicle controller action.
    /// </summary>
    public class RentVehicleReqDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleReqDto"/> class.
        /// Constructor.
        /// </summary>
        /// <param name="vehicleId">vehicleId.</param>
        /// <param name="renterDto">renterDto.</param>
        public RentVehicleReqDto(Guid vehicleId, RenterDto renterDto)
        {
            VehicleId = vehicleId;

            RenterDto = renterDto;
        }

        /// <summary>
        /// Gets or sets the vehicleID from the vehicle to rent.
        /// </summary>
        [Required]
        public Guid VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the renterDto.
        /// </summary>
        [Required]
        public RenterDto RenterDto { get; set; }
    }
}
