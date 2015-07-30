using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoMvcDriver2.DataModel;
using MongoMvcDriver2.Interface;
using MongoMvcDriver2.Repository;

namespace MongoMvcDriver2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Add(User user )
        {
            IUserRepository _UserRepository = new UserRepository();

            if (_UserRepository.Add(user)!=null)
            {
                return Json(new { error = false });
            }
            else
            {
                return Json(new { error = false });
            }
        }

        public ActionResult AllUser()
        {
            IUserRepository _UserRepository = new UserRepository();

            return Json(_UserRepository.GetAllEmployees());
        }
    }
}