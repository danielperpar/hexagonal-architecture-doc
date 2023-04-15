#pragma warning disable SA1600

using System;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    public readonly struct Name
    {
        private readonly string _firstName = string.Empty;
        private readonly string _lastName = string.Empty;

        public Name(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public override string ToString()
        {
            return $"{_firstName} {_lastName}";
        }
    }
}
