﻿#pragma warning disable SA1600

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetVehicles
{
    public sealed class GetVehiclesUseCase : IUseCase<GetVehiclesInput>
    {
        private readonly IRepository<Vehicle> _repository;
        private readonly IOutputPortStandard<GetVehiclesOutput> _getVehiclesOutputPortStandard;
        private readonly IGetVehiclesOutputPortNotFound _getVehiclesOutputPortNotFound;

        public GetVehiclesUseCase(
            IRepository<Vehicle> repository,
            IOutputPortStandard<GetVehiclesOutput> getVehiclesOutputPortStandard,
            IGetVehiclesOutputPortNotFound getVehiclesOutputPortNotFound)
        {
            _repository = repository;
            _getVehiclesOutputPortStandard = getVehiclesOutputPortStandard;
            _getVehiclesOutputPortNotFound = getVehiclesOutputPortNotFound;
        }

        public async Task Execute(GetVehiclesInput input)
        {
            var vehicles = await _repository.GetAll();

            var vehicleDtos = new List<VehicleDto>();

            foreach (var vehicle in vehicles)
            {
                var vehicleDto = new VehicleDto(
                    vehicle.VehicleId,
                    vehicle.TradeMark.Value,
                    vehicle.Model.Value,
                    vehicle.PlateNumber.Value,
                    vehicle.FabricationYear.Value);

                if (vehicle.Renter != null)
                {
                    var renterDto = new RenterDto(
                        vehicle.Renter.RenterId,
                        vehicle.Renter.Name.Value,
                        vehicle.Renter.TaxIdNumber.Value,
                        vehicle.Renter.PhoneNumber.Value);

                    vehicleDto.Renter = renterDto;
                }

                vehicleDtos.Add(vehicleDto);
            }

            BuildOutput(vehicleDtos);
        }

        private void BuildOutput(IEnumerable<VehicleDto> vehicles)
        {
            if (vehicles.Any())
            {
                var output = new GetVehiclesOutput(vehicles);
                _getVehiclesOutputPortStandard.StandardHandle(output);
                return;
            }

            _getVehiclesOutputPortNotFound.NotFoundHandle("There are no vehicles in the fleet");
        }
    }
}
