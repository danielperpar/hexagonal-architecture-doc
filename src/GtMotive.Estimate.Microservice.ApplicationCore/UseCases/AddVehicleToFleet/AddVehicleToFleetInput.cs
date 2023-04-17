using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;

namespace GtMotive.Estimate.Microservice.Api.UseCases.AddVehicleToFleet
{
    /// <summary>
    /// Input to be provided to the AddVehicleToFleet use case.
    /// </summary>
    public class AddVehicleToFleetInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddVehicleToFleetInput"/> class.
        /// Constructor.
        /// </summary>
        /// <param name="vehicleDto">vehicleDto.</param>
        public AddVehicleToFleetInput(VehicleDto vehicleDto)
        {
            VehicleDto = vehicleDto;
        }

        /// <summary>
        /// Gets the vehicle to be added to the fleet.
        /// </summary>
        public VehicleDto VehicleDto { get; private set; }
    }
}
