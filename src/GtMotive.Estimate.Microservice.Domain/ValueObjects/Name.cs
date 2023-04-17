using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Name value object.
    /// </summary>
    public readonly struct Name
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Name"/> struct.
        /// </summary>
        /// <param name="name">name.</param>
        /// <exception cref="DomainException">validation exception.</exception>
        public Name(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("Name cannot be empty");
            }

            Value = name.Trim().ToUpperInvariant();
        }

        /// <summary>
        /// Gets the name value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// /// Creation method.
        /// </summary>
        /// <param name="input">input.</param>
        /// <returns>name.</returns>
        public static Name Create(string input)
        {
            return new Name(input);
        }
    }
}
