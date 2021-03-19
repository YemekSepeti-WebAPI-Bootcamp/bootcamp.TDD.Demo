using System;
using System.Collections.Generic;
using System.Text;

namespace bootcamp.TDD.Demo.Core.Settings
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }
    }
}
