#pragma warning disable SA1600

using System;
using System.Globalization;
using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    public readonly struct FabricationYear
    {
        private const int MaxYears = 5;

        public FabricationYear(string year)
        {
            if (string.IsNullOrWhiteSpace(year))
            {
                throw new DomainException("Year cannot be empty");
            }

            var trimmedYear = year.Trim();

            var oldestAllowedYear = DateTime.Now.Year - MaxYears;

            if (int.Parse(trimmedYear, new CultureInfo("es-ES")) < oldestAllowedYear)
            {
                throw new DomainException($"Fabrication Year cannot be below {oldestAllowedYear}");
            }

            YearValue = year;
        }

        public string YearValue { get; }

        public static FabricationYear Create(string input)
        {
            return new FabricationYear(input);
        }
    }
}
