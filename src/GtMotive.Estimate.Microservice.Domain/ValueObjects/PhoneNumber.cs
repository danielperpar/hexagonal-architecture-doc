#pragma warning disable SA1600

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    public readonly struct PhoneNumber
    {
        private readonly string _prefix;
        private readonly string _number;

        public PhoneNumber(string prefix, string number)
        {
            _prefix = prefix;
            _number = number;
        }

        public override string ToString()
        {
            return $"{_prefix} {_number}";
        }
    }
}
