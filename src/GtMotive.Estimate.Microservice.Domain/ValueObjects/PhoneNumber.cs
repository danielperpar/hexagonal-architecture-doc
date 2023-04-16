#pragma warning disable SA1600

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    public readonly struct PhoneNumber
    {
        public PhoneNumber(string phoneNumber)
        {
            PhoneNumberValue = phoneNumber;
        }

        public string PhoneNumberValue { get; }
    }
}
