#pragma warning disable SA1600

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    public readonly struct Name
    {
        public Name(string name)
        {
            NameValue = name;
        }

        public string NameValue { get; }
    }
}
