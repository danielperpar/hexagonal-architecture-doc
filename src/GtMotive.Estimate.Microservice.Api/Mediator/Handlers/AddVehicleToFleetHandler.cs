using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Mediator.Requests;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.AddVehicleToFleet;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Mediator.Handlers
{
    public class AddVehicleToFleetHandler : IRequestHandler<AddVehicleToFleetRequest, IWebApiPresenter>
    {
        private readonly IWebApiPresenter _addVehicleToFleetPresenter;
        private readonly IUseCase<AddVehicleToFleetInput> _addVehicleToFleetUseCase;

        public AddVehicleToFleetHandler(
            IWebApiPresenter webApiPresenter,
            IUseCase<AddVehicleToFleetInput> addVehicleToFleetUseCase)
        {
            _addVehicleToFleetPresenter = webApiPresenter;
            _addVehicleToFleetUseCase = addVehicleToFleetUseCase;
        }

        public Task<IWebApiPresenter> Handle(AddVehicleToFleetRequest request, CancellationToken cancellationToken)
        {
            var vehicleDto = request?.VehicleDto;
            var input = new AddVehicleToFleetInput(vehicleDto);
            _addVehicleToFleetUseCase.Execute(input);
            return Task.FromResult(_addVehicleToFleetPresenter);
        }
    }
}
