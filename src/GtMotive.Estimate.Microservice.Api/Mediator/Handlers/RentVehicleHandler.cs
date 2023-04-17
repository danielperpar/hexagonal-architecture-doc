using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Mediator.Requests;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Mediator.Handlers
{
    public class RentVehicleHandler : IRequestHandler<RentVehicleRequest, IRentVehiclePresenter>
    {
        private readonly IRentVehiclePresenter _rentVehiclePresenter;
        private readonly IUseCase<RentVehicleInput> _rentVehicleUseCase;

        public RentVehicleHandler(
            IRentVehiclePresenter rentVehiclePresenter,
            IUseCase<RentVehicleInput> rentVehicleUseCase)
        {
            _rentVehiclePresenter = rentVehiclePresenter;
            _rentVehicleUseCase = rentVehicleUseCase;
        }

        public async Task<IRentVehiclePresenter> Handle(RentVehicleRequest request, CancellationToken cancellationToken)
        {
            var input = new RentVehicleInput(request?.RentVehicleReqDto);
            await _rentVehicleUseCase.Execute(input);
            return _rentVehiclePresenter;
        }
    }
}
