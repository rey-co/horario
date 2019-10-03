using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
//using MongoDB.Driver.Builders;
//using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
namespace Horario
{
    public class MongoDataService
    {
        /*private MongoServer server;
        private string database { get; set; }
        public MongoDataService(string connectionString)
        {
            MongoClient client = new MongoClient(connectionString);
            server = client.GetServer();
        }

        public string findOne(string databaseName, string collectionName, string query)
        {
            var db = server.GetDatabase(databaseName);
            var collection = db.GetCollection(collectionName);
            BsonDocument bsonDoc = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(query);

            var result = collection.FindOne(new QueryDocument(bsonDoc));
            if (result != null)
            {
                return result.ToJson();
            }
            else
            {
                return "";
            }
        }*/
    }
}
