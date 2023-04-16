using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Mediator.Requests
{
    public class RentVehicleRequest : IRequest<IRentVehiclePresenter>
    {
        public RentVehicleReqDto RentVehicleReqDto { get; set; }
    }
}
