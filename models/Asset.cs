using System;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbConsoleDemo.Models
{
    public class Asset
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [DataMember]
        [BsonElement("code")]
        public string Code { get; set; }

        [DataMember]
        [BsonElement("dateMeasure")]
        public DateTime DateMeasure { get; set; }

        [DataMember]
        [BsonElement("dateCreate")]
        public DateTime DateCreate { get; set; }
    }
}