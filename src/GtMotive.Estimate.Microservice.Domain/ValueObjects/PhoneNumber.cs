using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// PhoneNumber value object.
    /// </summary>
    public readonly struct PhoneNumber
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumber"/> struct.
        /// </summary>
        /// <param name="phoneNumber">phoneNumber.</param>
        /// <exception cref="DomainException">validation exception.</exception>
        public PhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new DomainException("Name cannot be empty");
            }

            Value = phoneNumber.Trim();
        }

        /// <summary>
        /// Gets the phoneNumber value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// /// Creation method.
        /// </summary>
        /// <param name="input">input.</param>
        /// <returns>phoneNumber.</returns>
        public static PhoneNumber Create(string input)
        {
            return new PhoneNumber(input);
        }
    }
}
