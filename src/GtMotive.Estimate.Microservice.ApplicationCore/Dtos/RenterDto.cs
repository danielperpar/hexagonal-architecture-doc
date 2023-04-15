using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Dtos
{
    /// <summary>
    /// Person who rents a vehicle.
    /// </summary>
    public class RenterDto
    {
        public RenterDto(Guid renderId, string firstName, string lastName, string taxIdNumber, string phoneNumber)
        {
            RenderId = renderId;
            FirstName = firstName;
            LastName = lastName;
            TaxIdNumber = taxIdNumber;
            PhoneNumber = phoneNumber;
        }

        public Guid RenderId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TaxIdNumber { get; set; }

        public string PhoneNumber { get; set; }
    }
}
