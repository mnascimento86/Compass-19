using MongoDB.Driver;
using System;

namespace SuccessFactorsDAL
{
    public class MongodbConnection
    {
        public IMongoDatabase database { get; set; }

        public MongodbConnection()
        {
            IMongoClient client = new MongoClient("mongodb://localhost:27017");
            this.database = client.GetDatabase("compass19");
        }


    }
}
