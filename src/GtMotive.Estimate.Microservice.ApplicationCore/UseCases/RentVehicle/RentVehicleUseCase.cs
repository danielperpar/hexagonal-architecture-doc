#pragma warning disable SA1600

using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    public sealed class RentVehicleUseCase : IUseCase<RentVehicleInput>
    {
        private readonly IRepository<Vehicle> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOutputPortStandard<RentVehicleOutput> _rentVehicleOutputPortStandard;
        private readonly IRentVehicleOutportNotFound _rentVehicleOutportNotFound;

        public RentVehicleUseCase(
             IRepository<Vehicle> repository,
             IUnitOfWork unitOfWork,
             IOutputPortStandard<RentVehicleOutput> rentVehicleOutputPortStandard,
             IRentVehicleOutportNotFound rentVehicleOutportNotFound)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _rentVehicleOutputPortStandard = rentVehicleOutputPortStandard;
            _rentVehicleOutportNotFound = rentVehicleOutportNotFound;
        }

        public async Task Execute(RentVehicleInput input)
        {
            // revisar esto
            if (input == null)
            {
                return;
            }

            var vehicle = await _repository.GetById(input.RentVehicleReqDto.VehicleId);

            if (vehicle != null && vehicle.Renter == null)
            {
                var renter = new Renter(
                    input.RentVehicleReqDto.RenterDto.RenterId,
                    new Name(input.RentVehicleReqDto.RenterDto.Name),
                    new TaxIdNumber(input.RentVehicleReqDto.RenterDto.TaxIdNumber),
                    new PhoneNumber(input.RentVehicleReqDto.RenterDto.PhoneNumber));

                vehicle.Renter = renter;

                _repository.Update(vehicle);
                await _unitOfWork.Save();
            }

            BuildOutput(vehicle);
        }

        private void BuildOutput(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                _rentVehicleOutportNotFound.NotFoundHandle("Vehicle not found.");
                return;
            }

            if (vehicle.Renter != null)
            {
                _rentVehicleOutportNotFound.NotFoundHandle("Vehicle has not available to rent.");
                return;
            }

            var vehicleDto = new VehicleDto(
                vehicle.VehicleId,
                vehicle.TradeMark.Value,
                vehicle.Model.Value,
                vehicle.PlateNumber.Value,
                vehicle.FabricationYear.Value);

            var renterDto = new RenterDto(
                vehicle.Renter.RenterId,
                vehicle.Renter.Name.Value,
                vehicle.Renter.TaxIdNumber.Value,
                vehicle.Renter.PhoneNumber.Value);

            vehicleDto.Renter = renterDto;

            var output = new RentVehicleOutput(vehicleDto);
            _rentVehicleOutputPortStandard.StandardHandle(output);
        }
    }
}
