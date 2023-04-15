using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Mediator.Requests
{
    public class AddVehicleToFleetRequest : IRequest<IWebApiPresenter>
    {
        public VehicleDto VehicleDto { get; set; }
    }
}
