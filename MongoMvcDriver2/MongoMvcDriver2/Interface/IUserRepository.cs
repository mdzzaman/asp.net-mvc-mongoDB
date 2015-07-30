using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MongoMvcDriver2.DataModel;

namespace MongoMvcDriver2.Interface
{
    public interface IUserRepository
    {
        User Add(User p);
        IEnumerable<User> GetAllEmployees();
    }
}
