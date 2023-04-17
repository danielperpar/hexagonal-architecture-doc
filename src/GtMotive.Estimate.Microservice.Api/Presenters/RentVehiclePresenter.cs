﻿using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    public class RentVehiclePresenter : IRentVehiclePresenter, IOutputPortStandard<RentVehicleOutput>, IRentVehicleOutportNotFound
    {
        public IActionResult ActionResult { get; private set; }

        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }

        public void StandardHandle(RentVehicleOutput response)
        {
            ActionResult = new OkObjectResult(response?.VehicleDto);
        }
    }
}
