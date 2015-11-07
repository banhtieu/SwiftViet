using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftViet.Data.Models
{

    /// <summary>
    /// The Base class for all Entity
    /// </summary>
    public class Entity
    {

        /// <summary>
        /// The Id
        /// </summary>
        public ObjectId Id { get; set; }
    }
}
