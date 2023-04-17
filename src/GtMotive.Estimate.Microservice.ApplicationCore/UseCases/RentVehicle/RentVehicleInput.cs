using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Input to be provided to the RentVehicle use case.
    /// </summary>
    public class RentVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleInput"/> class.
        /// </summary>
        /// <param name="rentVehicleReqDto">rentVehicleReqDto.</param>
        public RentVehicleInput(RentVehicleReqDto rentVehicleReqDto)
        {
            RentVehicleReqDto = rentVehicleReqDto;
        }

        /// <summary>
        /// Gets RentVehicleReqDto.
        /// </summary>
        public RentVehicleReqDto RentVehicleReqDto { get; private set; }
    }
}
