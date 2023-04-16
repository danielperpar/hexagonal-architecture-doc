using System;
using System.ComponentModel.DataAnnotations;

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
        /// <param name="name">first name.</param>
        /// <param name="taxIdNumber">tax Id number.</param>
        /// <param name="phoneNumber">phone number.</param>
        public RenterDto(Guid renterId, string name, string taxIdNumber, string phoneNumber)
        {
            RenterId = renterId;
            Name = name;
            TaxIdNumber = taxIdNumber;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Gets or Sets the renter id.
        /// </summary>
        [Required]
        public Guid RenterId { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tax Id Number.
        /// </summary>
        [Required]
        public string TaxIdNumber { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; }
    }
}
