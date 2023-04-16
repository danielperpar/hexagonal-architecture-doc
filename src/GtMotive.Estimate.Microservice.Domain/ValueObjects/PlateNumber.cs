#pragma warning disable SA1600

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    public readonly struct PlateNumber
    {
        public PlateNumber(string plateNumber)
        {
            PlateNumberValue = plateNumber;
        }

        public string PlateNumberValue { get; }
    }
}
