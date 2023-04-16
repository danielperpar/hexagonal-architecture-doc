#pragma warning disable SA1600

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    public readonly struct TaxIdNumber
    {
        public TaxIdNumber(string taxIdNumber)
        {
            TaxIdNumberValue = taxIdNumber;
        }

        public string TaxIdNumberValue { get; }
    }
}
