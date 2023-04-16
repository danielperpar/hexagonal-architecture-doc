#pragma warning disable SA1600

using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    public readonly struct PlateNumber
    {
        public PlateNumber(string plateNumber)
        {
            if (string.IsNullOrWhiteSpace(plateNumber))
            {
                throw new DomainException("PlateNumber cannot be empty");
            }

            PlateNumberValue = plateNumber.Trim().ToUpperInvariant();
        }

        public string PlateNumberValue { get; }

        public static PlateNumber Create(string input)
        {
            return new PlateNumber(input);
        }
    }
}
