#pragma warning disable SA1600

using System.Collections.Generic;
using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetVehicles
{
    public sealed class GetVehiclesOutput : IUseCaseOutput
    {
        public GetVehiclesOutput(IEnumerable<VehicleDto> vehicles)
        {
            Vehicles = vehicles;
        }

        public IEnumerable<VehicleDto> Vehicles { get; set; }
    }
}
