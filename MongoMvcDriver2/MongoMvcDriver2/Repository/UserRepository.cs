using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoMvcDriver2.DataModel;
using MongoMvcDriver2.Interface;


namespace MongoMvcDriver2.Repository
{
    public class UserRepository : IUserRepository
    {
        MongoServer mongoServer = null;
        MongoDatabase mDB = null;
        MongoCollection mCollection = null;

        public UserRepository()
        {
            try
            {
                var port = 27017;
                var theConnectionString = "mongodb://localhost:" + port;
                var dbName = "yourDBName";

                var client = new MongoClient(theConnectionString);
                var server = client.GetServer();
                mDB = server.GetDatabase(dbName);
                mCollection = mDB.GetCollection<User>("User");

                //mongoServer = MongoServer.Create();
                //mongoServer.Connect();
                //mDB = mongoServer.GetDatabase("TestMongoDB");
                //mCollection = mDB.GetCollection<User>("User");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public User Add(User user)
        {
            if (string.IsNullOrEmpty(user.Id))
            {
                user.Id = Guid.NewGuid().ToString();
            }
            mCollection.Save(user);
            return user;
        }
        private List<User> _employeesList = new List<User>();

        public IEnumerable<User> GetAllEmployees()
        {
            if (Convert.ToInt32(mCollection.Count()) > 0)
            {

                _employeesList.Clear();
                var employees = mCollection.FindAllAs(typeof(User));
                if (employees.Count() > 0)
                {
                    foreach (User employee in employees)
                    {
                        _employeesList.Add(employee);
                    }
                }
            }
            var result = _employeesList.AsQueryable();
            return result;
        }

    }
}