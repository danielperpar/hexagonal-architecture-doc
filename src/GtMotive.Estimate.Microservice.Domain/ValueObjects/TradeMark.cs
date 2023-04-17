using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// TradeMark value object.
    /// </summary>
    public readonly struct TradeMark
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TradeMark"/> struct.
        /// </summary>
        /// <param name="tradeMark">tradeMark.</param>
        /// <exception cref="DomainException">validation exception.</exception>
        public TradeMark(string tradeMark)
        {
            if (string.IsNullOrWhiteSpace(tradeMark))
            {
                throw new DomainException("TradeMark cannot be empty");
            }

            Value = tradeMark.Trim().ToUpperInvariant();
        }

        /// <summary>
        /// Gets the tradeMark value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// /// Creation method.
        /// </summary>
        /// <param name="input">input.</param>
        /// <returns>tradeMark.</returns>
        public static TradeMark Create(string input)
        {
            return new TradeMark(input);
        }
    }
}
