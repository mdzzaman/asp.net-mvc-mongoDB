using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoMvcDriver2.Models;
using MongoMvcDriver2.Properties;

namespace MongoMvcDriver2.App_Start
{
    public class RealEstateContext
    {
        protected static IMongoClient _client;
protected static IMongoDatabase _database;


        public RealEstateContext()
        {
            _client = new MongoClient(Settings.Default.RealEstateConnectionString);
            _database = _client.GetDatabase(Settings.Default.RealEstateDatabaseName);
        }

        public IMongoCollection<Rental> Rentals
        {
            get { return _database.GetCollection<Rental>("rentals"); }
        } 
    }
}