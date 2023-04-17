using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Mediator.Requests;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.AddVehicleToFleet;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Mediator.Handlers
{
    public class AddVehicleToFleetHandler : IRequestHandler<AddVehicleToFleetRequest, IAddVehicleToFleetPresenter>
    {
        private readonly IAddVehicleToFleetPresenter _addVehicleToFleetPresenter;
        private readonly IUseCase<AddVehicleToFleetInput> _addVehicleToFleetUseCase;

        public AddVehicleToFleetHandler(
            IAddVehicleToFleetPresenter webApiPresenter,
            IUseCase<AddVehicleToFleetInput> addVehicleToFleetUseCase)
        {
            _addVehicleToFleetPresenter = webApiPresenter;
            _addVehicleToFleetUseCase = addVehicleToFleetUseCase;
        }

        public async Task<IAddVehicleToFleetPresenter> Handle(AddVehicleToFleetRequest request, CancellationToken cancellationToken)
        {
            var vehicleDto = request?.VehicleDto;
            var input = new AddVehicleToFleetInput(vehicleDto);
            await _addVehicleToFleetUseCase.Execute(input);
            return _addVehicleToFleetPresenter;
        }
    }
}
