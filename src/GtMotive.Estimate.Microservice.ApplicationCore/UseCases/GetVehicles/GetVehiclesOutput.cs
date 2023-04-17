using System.Collections.Generic;
using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetVehicles
{
    /// <summary>
    /// Output from the GetVehicles use case.
    /// </summary>
    public sealed class GetVehiclesOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetVehiclesOutput"/> class.
        /// </summary>
        /// <param name="vehicles">vehicles.</param>
        public GetVehiclesOutput(IEnumerable<VehicleDto> vehicles)
        {
            VehicleDtos = vehicles;
        }

        /// <summary>
        /// Gets the output vehicles.
        /// </summary>
        public IEnumerable<VehicleDto> VehicleDtos { get; private set; }
    }
}
