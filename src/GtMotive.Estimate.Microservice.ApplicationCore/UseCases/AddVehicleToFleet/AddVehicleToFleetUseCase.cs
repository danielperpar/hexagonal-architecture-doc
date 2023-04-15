using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.AddVehicleToFleet;
using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicleToFleet;

#pragma warning disable SA1600

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Implementations
{
    /// <summary>
    /// Use case representing the addition of a vehicle to the fleet.
    /// </summary>
    public sealed class AddVehicleToFleetUseCase : IUseCase<AddVehicleToFleetInput>
    {
        private readonly IOutputPortStandard<AddVehicleToFleetOutput> _addVehicleOutputPort;

        public AddVehicleToFleetUseCase(IOutputPortStandard<AddVehicleToFleetOutput> addVehicleOutputPort)
        {
            _addVehicleOutputPort = addVehicleOutputPort;
        }

        public Task Execute(AddVehicleToFleetInput input)
        {
            BuildOutput(input?.VehicleDto);
            return Task.CompletedTask;
        }

        private void BuildOutput(VehicleDto vehicleDto)
        {
            var output = new AddVehicleToFleetOutput(vehicleDto);

            _addVehicleOutputPort.StandardHandle(output);
        }
    }
}
