using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetVehicles;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.UnitTests.ApplicationCore.TestData;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore
{
    public class GetVehiclesUseCaseTest
    {
        private readonly Mock<IRepository<Vehicle>> _mockRepository;
        private readonly Mock<IOutputPortStandard<GetVehiclesOutput>> _mockOutputPortStandard;
        private readonly Mock<IGetVehiclesOutputPortNotFound> _mockOutputPortNotFound;

        public GetVehiclesUseCaseTest()
        {
            _mockRepository = new Mock<IRepository<Vehicle>>();
            _mockOutputPortStandard = new Mock<IOutputPortStandard<GetVehiclesOutput>>();
            _mockOutputPortNotFound = new Mock<IGetVehiclesOutputPortNotFound>();
        }

        [Fact]
        public async Task GetVehiclesWithVehiclesInTheFleet()
        {
            var testVehicles = GetVehiclesTestData.GetVehicles();

            _mockRepository.Setup(x => x.GetAll()).ReturnsAsync(testVehicles);
            _mockOutputPortStandard.Setup(x => x.StandardHandle(It.IsAny<GetVehiclesOutput>())).Verifiable();

            var sut = new GetVehiclesUseCase(
                _mockRepository.Object,
                _mockOutputPortStandard.Object,
                _mockOutputPortNotFound.Object);

            await sut.Execute(GetVehiclesTestData.Input());

            _mockOutputPortStandard.Verify();
        }

        [Fact]
        public async Task GetVehiclesWithEmptyFleet()
        {
            var emptyVehiclesList = new List<Vehicle>();
            _mockRepository.Setup(x => x.GetAll()).ReturnsAsync(emptyVehiclesList);
            _mockOutputPortNotFound.Setup(x => x.NotFoundHandle(It.IsAny<string>())).Verifiable();

            var sut = new GetVehiclesUseCase(
                _mockRepository.Object,
                _mockOutputPortStandard.Object,
                _mockOutputPortNotFound.Object);

            await sut.Execute(GetVehiclesTestData.Input());

            _mockOutputPortNotFound.Verify();
        }
    }
}
