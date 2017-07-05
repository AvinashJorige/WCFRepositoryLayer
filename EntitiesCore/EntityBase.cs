using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;

namespace EntitiesCore
{
    [DataContract]
    public abstract class EntityBase
    {
        [DataMember]
        //[BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }
    }
}
