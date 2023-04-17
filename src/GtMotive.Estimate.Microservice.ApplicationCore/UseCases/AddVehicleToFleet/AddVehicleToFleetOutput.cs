using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicleToFleet
{
    /// <summary>
    /// Response instantiated by the use case and given to the presenter.
    /// </summary>
    public sealed class AddVehicleToFleetOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddVehicleToFleetOutput"/> class.
        /// </summary>
        /// <param name="vehicleDto">vehicleDto.</param>
        public AddVehicleToFleetOutput(VehicleDto vehicleDto)
        {
            VehicleDto = vehicleDto;
        }

        /// <summary>
        /// Gets the vehicle added to the fleet.
        /// </summary>
        public VehicleDto VehicleDto { get; private set; }
    }
}
