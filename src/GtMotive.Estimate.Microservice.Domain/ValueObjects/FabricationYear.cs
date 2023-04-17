using System;
using System.Globalization;
using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// FabricationYear value object.
    /// </summary>
    public readonly struct FabricationYear
    {
        private const int MaxYears = 5;

        /// <summary>
        /// Initializes a new instance of the <see cref="FabricationYear"/> struct.
        /// </summary>
        /// <param name="year">year.</param>
        /// <exception cref="DomainException">validation exception.</exception>
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

            Value = year;
        }

        /// <summary>
        /// Gets the fabricationYear value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Creation method.
        /// </summary>
        /// <param name="input">input.</param>
        /// <returns>fabricationYear.</returns>
        public static FabricationYear Create(string input)
        {
            return new FabricationYear(input);
        }
    }
}
