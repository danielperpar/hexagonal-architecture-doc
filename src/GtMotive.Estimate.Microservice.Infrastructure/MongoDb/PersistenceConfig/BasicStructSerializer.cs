﻿#pragma warning disable CA1062
#pragma warning disable S2259

using System.Collections.Generic;
using System.Reflection;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.PersistenceConfig
{
    public class BasicStructSerializer<T> : StructSerializerBase<T>
        where T : struct
    {
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, T value)
        {
            var nominalType = args.NominalType;
            var propsAll = nominalType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            var props = new List<PropertyInfo>();
            foreach (var prop in propsAll)
            {
                props.Add(prop);
            }

            var bsonWriter = context.Writer;

            bsonWriter?.WriteStartDocument();

            foreach (var prop in props)
            {
                bsonWriter.WriteName(prop.Name);
                BsonSerializer.Serialize(bsonWriter, prop.PropertyType, prop.GetValue(value, null));
            }

            bsonWriter.WriteEndDocument();
        }

        public override T Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var obj = (object)default(T);
            var actualType = args.NominalType;
            var bsonReader = context.Reader;
            object ret = null;

            bsonReader.ReadStartDocument();

            while (bsonReader.ReadBsonType() != BsonType.EndOfDocument)
            {
                var name = bsonReader.ReadName();
                var prop = actualType.GetProperty(name);
                var value = BsonSerializer.Deserialize(bsonReader, prop.PropertyType);
                var param = new object[] { value };
                ret = actualType.GetMethod("Create").Invoke(obj, param);
            }

            bsonReader.ReadEndDocument();

            return (T)ret;
        }
    }
}
