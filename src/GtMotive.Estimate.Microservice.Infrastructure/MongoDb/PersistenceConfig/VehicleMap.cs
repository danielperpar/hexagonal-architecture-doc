using GtMotive.Estimate.Microservice.Domain.Aggregates;
using MongoDB.Bson.Serialization;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.PersistenceConfig
{
    public static class VehicleMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Vehicle>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.VehicleId);
            });
        }
    }
}
