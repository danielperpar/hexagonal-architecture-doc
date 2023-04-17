using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicleToFleet;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    public class AddVehicleToFleetPresenter : IAddVehicleToFleetPresenter, IOutputPortStandard<AddVehicleToFleetOutput>
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(AddVehicleToFleetOutput response)
        {
            var vehicleDto = response?.VehicleDto;

            ActionResult = new OkObjectResult(vehicleDto);
        }
    }
}
