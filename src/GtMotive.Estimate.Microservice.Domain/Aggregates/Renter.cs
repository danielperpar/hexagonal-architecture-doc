using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Aggregates
{
    /// <summary>
    /// Renter.
    /// </summary>
    public class Renter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Renter"/> class.
        /// </summary>
        /// <param name="renterId">renterId.</param>
        /// <param name="name">name.</param>
        /// <param name="taxIdNumber">taxIdNumber.</param>
        /// <param name="phoneNumber">phoneNumber.</param>
        public Renter(Guid renterId, Name name, TaxIdNumber taxIdNumber, PhoneNumber phoneNumber)
        {
            RenterId = renterId;
            Name = name;
            TaxIdNumber = taxIdNumber;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Gets or sets renterId.
        /// </summary>
        public Guid RenterId { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public Name Name { get; set; }

        /// <summary>
        /// Gets or sets taxIdNumber.
        /// </summary>
        public TaxIdNumber TaxIdNumber { get; set; }

        /// <summary>
        /// Gets or sets phoneNumber.
        /// </summary>
        public PhoneNumber PhoneNumber { get; set; }
    }
}
