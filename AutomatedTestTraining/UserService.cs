using System;
using System.Security.Authentication;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace BusinessLogic
{
    public class UserService
    {
        public UserService()
        {}

        public async Task AddUser(UserModel userToAdd)
        {
            await Collection().InsertOneAsync(userToAdd);
        }

        private IMongoCollection<UserModel> Collection()
        {
            string connectionString = Environment.GetEnvironmentVariable("MONGO_DB_CONNECTION_STRING");
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);

            var db = mongoClient.GetDatabase("userdb");
            return db.GetCollection<UserModel>("users");
        }
    }
}
