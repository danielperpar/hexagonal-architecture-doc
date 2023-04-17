using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Model value object.
    /// </summary>
    public readonly struct Model
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Model"/> struct.
        /// </summary>
        /// <param name="modelValue">modelValue.</param>
        /// <exception cref="DomainException">validation exception.</exception>
        public Model(string modelValue)
        {
            if (string.IsNullOrWhiteSpace(modelValue))
            {
                throw new DomainException("Model cannot be empty");
            }

            Value = modelValue.Trim().ToUpperInvariant();
        }

        /// <summary>
        /// Gets the model value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Creation method.
        /// </summary>
        /// <param name="input">input.</param>
        /// <returns>model.</returns>
        public static Model Create(string input)
        {
            return new Model(input);
        }
    }
}
