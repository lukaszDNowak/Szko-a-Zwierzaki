using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pizza.Models;

namespace Pizza.Controllers
{
    public class AnimalGroupsController : Controller
    {
        private DB db = new DB();

        // GET: AnimalGroups
        public async Task<ActionResult> Index()
        {
            return View(await db.AnimalGroups.ToListAsync());
        }

        // GET: AnimalGroups/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalGroup animalGroup = await db.AnimalGroups.FindAsync(id);
            if (animalGroup == null)
            {
                return HttpNotFound();
            }
            return View(animalGroup);
        }

        // GET: AnimalGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnimalGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] AnimalGroup animalGroup)
        {
            if (ModelState.IsValid)
            {
                db.AnimalGroups.Add(animalGroup);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(animalGroup);
        }

        // GET: AnimalGroups/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalGroup animalGroup = await db.AnimalGroups.FindAsync(id);
            if (animalGroup == null)
            {
                return HttpNotFound();
            }
            return View(animalGroup);
        }

        // POST: AnimalGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] AnimalGroup animalGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animalGroup).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(animalGroup);
        }

        // GET: AnimalGroups/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalGroup animalGroup = await db.AnimalGroups.FindAsync(id);
            if (animalGroup == null)
            {
                return HttpNotFound();
            }
            return View(animalGroup);
        }

        // POST: AnimalGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AnimalGroup animalGroup = await db.AnimalGroups.FindAsync(id);
            db.AnimalGroups.Remove(animalGroup);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
