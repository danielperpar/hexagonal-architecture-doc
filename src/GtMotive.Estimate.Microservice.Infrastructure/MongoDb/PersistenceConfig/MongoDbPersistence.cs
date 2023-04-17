using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.PersistenceConfig
{
    public static class MongoDbPersistence
    {
        public static void Configure()
        {
            VehicleMap.Configure();

            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.CSharpLegacy));

            BsonSerializer.RegisterSerializer(new BasicStructSerializer<Model>());
            BsonSerializer.RegisterSerializer(new BasicStructSerializer<Name>());
            BsonSerializer.RegisterSerializer(new BasicStructSerializer<PhoneNumber>());
            BsonSerializer.RegisterSerializer(new BasicStructSerializer<PlateNumber>());
            BsonSerializer.RegisterSerializer(new BasicStructSerializer<TaxIdNumber>());
            BsonSerializer.RegisterSerializer(new BasicStructSerializer<TradeMark>());
            BsonSerializer.RegisterSerializer(new BasicStructSerializer<FabricationYear>());

            // Conventions
            var pack = new ConventionPack
                {
                    new IgnoreExtraElementsConvention(true),
                    new IgnoreIfDefaultConvention(true)
                };
            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }
    }
}
