using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoBackend.Models;
using System.Text.Json.Nodes;

namespace MongoBackend.DatabaseHelper
{
    public class Database
    {
        public List<User> getUsers()
        {
            MongoClient mongoClient = new MongoClient("mongodb+srv://DB-ll:Nomelase123@cluster0.nbq2sxf.mongodb.net/test");

            IMongoDatabase db = mongoClient.GetDatabase("MongoBackend");

            var users = db.GetCollection<BsonDocument>("Users");

            List<BsonDocument> userArray = users.Find(new BsonDocument()).ToList();

            List<User> userList = new List<User>();

            foreach (BsonDocument bsonUser in userArray)
            {
                User user = BsonSerializer.Deserialize<User>(bsonUser);
                userList.Add(user);
            }

            return userList;
        }
        public void insertUser(string name, string email, int phone, string address)
        {
            MongoClient mongoClient = new MongoClient("mongodb+srv://DB-ll:Nomelase123@cluster0.nbq2sxf.mongodb.net/test");

            IMongoDatabase db = mongoClient.GetDatabase("MongoBackend");

            var users = db.GetCollection<BsonDocument>("Users");

            var doc = new BsonDocument
            {
                { "name", name },
                { "email", email },
                { "phone", phone },
                { "address", address},
                { "dateIn", DateTime.Today }
            };

            users.InsertOne(doc);
        }

        public List<User> getUser(string idUser)
        {
            MongoClient mongoClient = new MongoClient("mongodb+srv://DB-ll:Nomelase123@cluster0.nbq2sxf.mongodb.net/test");

            IMongoDatabase db = mongoClient.GetDatabase("MongoBackend");

            var users = db.GetCollection<BsonDocument>("Users");

            var doc = new BsonDocument
            {
                { "_id", ObjectId.Parse(idUser) }
            };

            List<BsonDocument> userArray = users.Find(doc).ToList();

            List<User> userList = new List<User>();

            foreach (BsonDocument bsonUser in userArray)
            {
                User user = BsonSerializer.Deserialize<User>(bsonUser);
                userList.Add(user);
            }

            return userList;
        }
        public void deleleUser(string idUser)
        {
            MongoClient mongoClient = new MongoClient("mongodb+srv://DB-ll:Nomelase123@cluster0.nbq2sxf.mongodb.net/test");

            IMongoDatabase db = mongoClient.GetDatabase("MongoBackend");

            var users = db.GetCollection<BsonDocument>("Users");

            var doc = new BsonDocument
            {
                { "_id", ObjectId.Parse(idUser) }
            };

            users.DeleteOne(doc);
        }
        public void updateUser(string idUser, string name, string email, string phone, string address)
        {
            MongoClient mongoClient = new MongoClient("mongodb+srv://DB-ll:Nomelase123@cluster0.nbq2sxf.mongodb.net/test");

            IMongoDatabase db = mongoClient.GetDatabase("MongoBackend");

            var users = db.GetCollection<BsonDocument>("Users");

            var doc = new BsonDocument
            {
                { "_id", ObjectId.Parse(idUser) }
            };


            var set1 = new BsonDocument
                {
                { "_id", ObjectId.Parse(idUser) },
                {"name", name },
                { "email", email} ,
                { "phone", phone},
                 {"address", address },
                 {"dateIn", DateTime.Today },
            };

            users.ReplaceOne(doc, set1);
        }

    }
}

