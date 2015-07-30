using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoMvcDriver2.DataModel
{
    public class User
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class ClintAllowedOrigin
    {
        public string AllowedOrigin { get; set; }
    }
}