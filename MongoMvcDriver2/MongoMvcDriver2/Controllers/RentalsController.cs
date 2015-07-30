using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoMvcDriver2.App_Start;
using MongoMvcDriver2.Models;
using MongoMvcDriver2.Properties;

namespace MongoMvcDriver2.Controllers
{
    public class RentalsController : Controller
    {
        RealEstateContext _db=new RealEstateContext();

        // GET: Rentals
        public async Task<ActionResult> Index()
        {
            //var collection =  _database.GetCollection<PostRental>("");
            var filter = new BsonDocument();
            var result = await _db.Rentals.FindAsync(filter);
            return View(result );
        }

        public ActionResult Post()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Post(PostRental post)
        {
 
            //var collection = _database.GetCollection<PostRental>("restaurants");
            var rental = new Rental(post);
            await _db.Rentals.InsertOneAsync(rental);
            return RedirectToAction("Index");
        } 
    }
}