#pragma warning disable SA1600

using GtMotive.Estimate.Microservice.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    public readonly struct PhoneNumber
    {
        public PhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new DomainException("Name cannot be empty");
            }

            if (!IsPhoneValid(phoneNumber))
            {
                throw new DomainException("Invalid phone number");
            }

            PhoneNumberValue = phoneNumber.Trim();
        }

        public string PhoneNumberValue { get; }

        public static PhoneNumber Create(string input)
        {
            return new PhoneNumber(input);
        }

        private static bool IsPhoneValid(string phoneNumber)
        {
            var regex = @"^([\+]?33[-]?|[0])?[1-9][0-9]{8}$";
            return phoneNumber != null && Regex.IsMatch(phoneNumber, regex);
        }
    }
}
