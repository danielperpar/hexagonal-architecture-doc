using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Dtos
{
    /// <summary>
    /// Person who rents a vehicle.
    /// </summary>
    public class RenterDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenterDto"/> class.
        /// </summary>
        /// <param name="renterId">renter Id.</param>
        /// <param name="firstName">first name.</param>
        /// <param name="lastName">last name.</param>
        /// <param name="taxIdNumber">tax Id number.</param>
        /// <param name="phoneNumber">phone number.</param>
        public RenterDto(Guid renterId, string firstName, string lastName, string taxIdNumber, string phoneNumber)
        {
            RenterId = renterId;
            FirstName = firstName;
            LastName = lastName;
            TaxIdNumber = taxIdNumber;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Gets or Sets the renter id.
        /// </summary>
        public Guid RenterId { get; set; }

        /// <summary>
        /// Gets or sets the first Name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the tax Id Number.
        /// </summary>
        public string TaxIdNumber { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
