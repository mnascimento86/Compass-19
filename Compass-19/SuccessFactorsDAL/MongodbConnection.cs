using MongoDB.Driver;
using System;

namespace SuccessFactorsDAL
{
    public class MongoDbConnect
    {
        public IMongoDatabase database { get; set; }

        public MongoDbConnect()
        {
            IMongoClient client = new MongoClient("mongodb://localhost:27017");
            this.database = client.GetDatabase("compass19");
        }


    }
}
