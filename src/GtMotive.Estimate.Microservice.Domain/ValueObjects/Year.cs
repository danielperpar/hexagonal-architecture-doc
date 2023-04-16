#pragma warning disable SA1600

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    public readonly struct Year
    {
        public Year(string year)
        {
            YearValue = year;
        }

        public string YearValue { get; }
    }
}
