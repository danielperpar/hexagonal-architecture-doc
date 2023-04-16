using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.AddVehicleToFleet;
using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicleToFleet;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

#pragma warning disable SA1600

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Implementations
{
    /// <summary>
    /// Use case representing the addition of a vehicle to the fleet.
    /// </summary>
    public sealed class AddVehicleToFleetUseCase : IUseCase<AddVehicleToFleetInput>
    {
        private readonly IRepository<Vehicle> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOutputPortStandard<AddVehicleToFleetOutput> _addVehicleOutputPort;

        public AddVehicleToFleetUseCase(
            IRepository<Vehicle> repository,
            IUnitOfWork unitOfWork,
            IOutputPortStandard<AddVehicleToFleetOutput> addVehicleOutputPort)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _addVehicleOutputPort = addVehicleOutputPort;
        }

        public async Task Execute(AddVehicleToFleetInput input)
        {
            var tradeMark = new TradeMark(input?.VehicleDto.TradeMark);
            var model = new Model(input?.VehicleDto.Model);
            var plateNumber = new PlateNumber(input?.VehicleDto.PlateNumber);
            var fabYear = new FabricationYear(input?.VehicleDto.FabricationYear);

            var vehicle = new Vehicle(Guid.NewGuid(), tradeMark, model, plateNumber, fabYear);

            _repository.Add(vehicle);
            await _unitOfWork.Save();

            BuildOutput(input?.VehicleDto);
        }

        private void BuildOutput(VehicleDto vehicleDto)
        {
            var output = new AddVehicleToFleetOutput(vehicleDto);

            _addVehicleOutputPort.StandardHandle(output);
        }
    }
}
