using Pizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pizza.Controllers
{
    public class Home2Controller : Controller
    {
        // GET: Home2
        public ActionResult Index()
        {
            var db = new DB();
            var list = db.Animals.Where(a => a.LegsCount < 100).ToList();
            return View(list);
        }

        public ActionResult Add(int? id)
        {
            var db = new DB();
            var dbAnimal = db.Animals.Find(id);
            return View(dbAnimal);
        }
        [HttpPost]
        public ActionResult SaveAnimal(Animal animal)
        {
            var db = new DB();
            if (animal.Id == 0)
            {
                db.Animals.Add(animal);
                db.SaveChanges();
            }
            else
            {
                //db.Animals.Where(a => a.Id == animal.Id).First();
                //db.Animals.Single(a => a.Id == animal.Id);
                var dbAnimal = db.Animals.Find(animal.Id);
                dbAnimal.Name = animal.Name;
                dbAnimal.LegsCount = animal.LegsCount;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}