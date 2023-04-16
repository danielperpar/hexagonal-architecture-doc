#pragma warning disable SA1600

using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    public readonly struct Model
    {
        public Model(string modelValue)
        {
            if (string.IsNullOrWhiteSpace(modelValue))
            {
                throw new DomainException("Model cannot be empty");
            }

            Value = modelValue.Trim().ToUpperInvariant();
        }

        public string Value { get; }

        public static Model Create(string input)
        {
            return new Model(input);
        }
    }
}
