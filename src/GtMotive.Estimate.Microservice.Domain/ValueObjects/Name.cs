#pragma warning disable SA1600

using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    public readonly struct Name
    {
        public Name(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("Name cannot be empty");
            }

            Value = name.Trim().ToUpperInvariant();
        }

        public string Value { get; }

        public static Name Create(string input)
        {
            return new Name(input);
        }
    }
}
