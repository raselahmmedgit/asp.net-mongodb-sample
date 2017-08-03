using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace lab.MongoDBApps.Models
{
    public class MongoDbContext
    {
        #region Private Variable
        MongoClient _client;
        MongoServer _server;
        private MongoDatabase _database;
        public MongoCollection<Product> Product;
        public MongoCollection<Student> Student;
        #endregion

        #region Constructor
        public MongoDbContext()
        {
            // Reading credentials from Web.config file   
            var mongoDatabaseName = ConfigurationManager.AppSettings["MongoDatabaseName"]; //MongoDbApps  
            var mongoUsername = ConfigurationManager.AppSettings["MongoUsername"]; //MongoDbApps_User  
            var mongoPassword = ConfigurationManager.AppSettings["MongoPassword"]; //admin123#@  
            var mongoPort = ConfigurationManager.AppSettings["MongoPort"];  //27017  
            var mongoHost = ConfigurationManager.AppSettings["MongoHost"];  //localhost  

            // Creating credentials  
            //var credential = MongoCredential.CreateMongoCRCredential
            //                (mongoDatabaseName,
            //                 mongoUsername,
            //                 mongoPassword);

            // Creating MongoClientSettings  
            var settings = new MongoClientSettings
            {
                //Credentials = new[] { credential },
                Server = new MongoServerAddress(mongoHost, Convert.ToInt32(mongoPort))
            };
            _client = new MongoClient(settings);
            _server = _client.GetServer();
            _database = _server.GetDatabase(mongoDatabaseName);
            Product = _database.GetCollection<Product>("Product");
            Student = _database.GetCollection<Student>("Student");
        }
        #endregion

        #region Method

        #endregion
    }
}