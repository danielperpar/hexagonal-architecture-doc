#pragma warning disable SA1600

using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    public sealed class RentVehicleOutput : IUseCaseOutput
    {
        public RentVehicleOutput(VehicleDto vehicleDto)
        {
            VehicleDto = vehicleDto;
        }

        public VehicleDto VehicleDto { get; set; }
    }
}
