#pragma warning disable SA1600

using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    public readonly struct TaxIdNumber
    {
        public TaxIdNumber(string taxIdNumber)
        {
            if (string.IsNullOrWhiteSpace(taxIdNumber))
            {
                throw new DomainException("PlateNumber cannot be empty");
            }

            TaxIdNumberValue = taxIdNumber.Trim().ToUpperInvariant();
        }

        public string TaxIdNumberValue { get; }

        public static TaxIdNumber Create(string input)
        {
            return new TaxIdNumber(input);
        }
    }
}
