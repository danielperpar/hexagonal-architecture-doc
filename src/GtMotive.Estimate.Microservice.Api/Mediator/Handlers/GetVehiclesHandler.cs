using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Mediator.Requests;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetVehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Mediator.Handlers
{
    public class GetVehiclesHandler : IRequestHandler<GetVehiclesRequest, IGetVehiclesPresenter>
    {
        private readonly IGetVehiclesPresenter _getVehiclesPresenter;
        private readonly IUseCase<GetVehiclesInput> _getVehiclesUseCase;

        public GetVehiclesHandler(
            IGetVehiclesPresenter getVehiclesPresenter,
            IUseCase<GetVehiclesInput> getVehiclesUseCase)
        {
            _getVehiclesPresenter = getVehiclesPresenter;
            _getVehiclesUseCase = getVehiclesUseCase;
        }

        public async Task<IGetVehiclesPresenter> Handle(GetVehiclesRequest request, CancellationToken cancellationToken)
        {
            var input = new GetVehiclesInput();
            await _getVehiclesUseCase.Execute(input);
            return _getVehiclesPresenter;
        }
    }
}
