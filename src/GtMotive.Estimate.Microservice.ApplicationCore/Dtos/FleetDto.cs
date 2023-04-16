using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Dtos
{
    /// <summary>
    /// Fleet of vehicles owned by the company.
    /// </summary>
    public class FleetDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FleetDto"/> class.
        /// Constructor.
        /// </summary>
        public FleetDto()
        {
            Vehicles = new List<VehicleDto>();
        }

        /// <summary>
        /// Gets vehicles.
        /// </summary>
        public ICollection<VehicleDto> Vehicles { get; private set; }
    }
}
