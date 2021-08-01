using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace API.Shared
{
    public class DBConnection : IDBConnection
    {
        public IMongoDatabase DataBase { get; set; }
        public IMongoClient Client { get; set; }
        public DBConnection(IConfiguration configuration, DataBaseSetting settings)
        {
            // Client = new MongoClient("mongodb+srv://hmc:hmc@cluster0.kvhlv.mongodb.net/<dbname>?ssl=true&authSource=admin&retryWrites=true&w=majority");
            Client = new MongoClient(settings.ConnectionString);
            // DataBase = Client.GetDatabase("HMC");
            DataBase = Client.GetDatabase(settings.DatabaseName);
            /*_users = database.GetCollection<User>("User");*/
        }

    }
    public interface IDBConnection 
    {
        public IMongoDatabase DataBase { get; set; }
        public IMongoClient Client { get; set; }
    }
}