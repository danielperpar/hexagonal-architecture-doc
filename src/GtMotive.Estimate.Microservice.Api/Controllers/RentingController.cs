using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Mediator.Requests;
using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("addVehicletoFleet")]
        [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddVehicletoFleet(VehicleDto vechicleDto)
        {
            var request = new AddVehicleToFleetRequest { VehicleDto = vechicleDto };
            var presenter = await _mediator.Send(request);

            return presenter.ActionResult;
        }
    }
}
