#pragma warning disable SA1600

using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    public sealed class RentVehicleInput : IUseCaseInput
    {
        public RentVehicleInput(RentVehicleReqDto rentVehicleReqDto)
        {
            RentVehicleReqDto = rentVehicleReqDto;
        }

        public RentVehicleReqDto RentVehicleReqDto { get; set; }
    }
}
