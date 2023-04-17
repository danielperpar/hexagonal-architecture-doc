using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// PlateNumber value object.
    /// </summary>
    public readonly struct PlateNumber
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlateNumber"/> struct.
        /// </summary>
        /// <param name="plateNumber">plateNumber.</param>
        /// <exception cref="DomainException">validation exception.</exception>
        public PlateNumber(string plateNumber)
        {
            if (string.IsNullOrWhiteSpace(plateNumber))
            {
                throw new DomainException("PlateNumber cannot be empty");
            }

            Value = plateNumber.Trim().ToUpperInvariant();
        }

        /// <summary>
        /// Gets the plateNumber value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// /// Creation method.
        /// </summary>
        /// <param name="input">input.</param>
        /// <returns>plateNumber.</returns>
        public static PlateNumber Create(string input)
        {
            return new PlateNumber(input);
        }
    }
}
