using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Clase2022.Entities;

    public class Tasks
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? Id  { get; set; }
        public String? taskName { get; set; }
        public Boolean isComplete { get; set; }
    }
