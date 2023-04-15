using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Dtos
{
    /// <summary>
    /// Fleet of vehicles owned by the company.
    /// </summary>
    public class FleetDto
    {
        public FleetDto()
        {
            Vehicles = new List<VehicleDto>();
        }

        public ICollection<VehicleDto> Vehicles { get; private set; }
    }
}
