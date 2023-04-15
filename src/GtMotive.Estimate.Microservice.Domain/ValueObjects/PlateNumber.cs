#pragma warning disable SA1600

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    public readonly struct PlateNumber
    {
        private readonly string _plateNumber;

        public PlateNumber(string plateNumber)
        {
            _plateNumber = plateNumber;
        }

        public override string ToString()
        {
            return _plateNumber;
        }
    }
}
