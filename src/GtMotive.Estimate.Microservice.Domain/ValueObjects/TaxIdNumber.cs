#pragma warning disable SA1600

using System;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    public readonly struct TaxIdNumber
    {
        private readonly string _taxIdNumber = string.Empty;

        public TaxIdNumber(string taxIdNumber)
        {
            _taxIdNumber = taxIdNumber;
        }

        public override string ToString()
        {
            return _taxIdNumber;
        }
    }
}
