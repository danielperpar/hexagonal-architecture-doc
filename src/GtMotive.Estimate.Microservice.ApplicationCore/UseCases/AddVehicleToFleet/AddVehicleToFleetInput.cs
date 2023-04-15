#pragma warning disable SA1600

using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;

namespace GtMotive.Estimate.Microservice.Api.UseCases.AddVehicleToFleet
{
    /// <summary>
    /// Input to be provided to the AddVehicleToFleet use case.
    /// </summary>
    public sealed class AddVehicleToFleetInput : IUseCaseInput
    {
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
