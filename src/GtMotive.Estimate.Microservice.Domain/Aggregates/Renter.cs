#pragma warning disable SA1600

using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Aggregates
{
    public sealed class Renter
    {
        public Renter(Guid renterId, Name name, TaxIdNumber taxIdNumber, PhoneNumber phoneNumber)
        {
            RenterId = renterId;
            Name = name;
            TaxIdNumber = taxIdNumber;
            PhoneNumber = phoneNumber;
        }

        public Guid RenterId { get; private set; }

        public Name Name { get; set; }

        public TaxIdNumber TaxIdNumber { get; set; }

        public PhoneNumber PhoneNumber { get; set; }
    }
}
