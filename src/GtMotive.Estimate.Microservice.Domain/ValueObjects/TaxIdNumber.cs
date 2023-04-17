using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// TaxIdNumber value object.
    /// </summary>
    public readonly struct TaxIdNumber
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxIdNumber"/> struct.
        /// </summary>
        /// <param name="taxIdNumber">taxIdNumber.</param>
        /// <exception cref="DomainException">validation exception.</exception>
        public TaxIdNumber(string taxIdNumber)
        {
            if (string.IsNullOrWhiteSpace(taxIdNumber))
            {
                throw new DomainException("PlateNumber cannot be empty");
            }

            Value = taxIdNumber.Trim().ToUpperInvariant();
        }

        /// <summary>
        /// Gets the taxIdNumber value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// /// Creation method.
        /// </summary>
        /// <param name="input">input.</param>
        /// <returns>taxIdNumber.</returns>
        public static TaxIdNumber Create(string input)
        {
            return new TaxIdNumber(input);
        }
    }
}
