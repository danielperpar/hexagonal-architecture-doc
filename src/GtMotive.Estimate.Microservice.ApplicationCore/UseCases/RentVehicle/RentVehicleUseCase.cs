using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Rent a vehicle.
    /// </summary>
    public sealed class RentVehicleUseCase : IUseCase<RentVehicleInput>
    {
        private readonly IRepository<Vehicle> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOutputPortStandard<RentVehicleOutput> _rentVehicleOutputPortStandard;
        private readonly IRentVehicleOutportNotFound _rentVehicleOutportNotFound;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleUseCase"/> class.
        /// </summary>
        /// <param name="repository">repository.</param>
        /// <param name="unitOfWork">unitOfWork.</param>
        /// <param name="rentVehicleOutputPortStandard">rentVehicleOutputPortStandard.</param>
        /// <param name="rentVehicleOutportNotFound">rentVehicleOutportNotFound.</param>
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

        /// <summary>
        /// Use case execution method.
        /// </summary>
        /// <param name="input">input.</param>
        /// <returns>empty task.</returns>
        public async Task Execute(RentVehicleInput input)
        {
            // problemas con el Guid. tengo que poner esto así...
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
