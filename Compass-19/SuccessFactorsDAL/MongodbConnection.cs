using MongoDB.Driver;
using System;

namespace SuccessFactorsDAL
{
    public class MongodbConnection
    {
        public IMongoDatabase database { get; set; }

        public MongodbConnection()
        {
            try
            {
                IMongoClient client = new MongoClient("mongodb://192.168.0.213:27017");

                this.database = client.GetDatabase("compass19");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}