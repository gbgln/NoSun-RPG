using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NoSun.DAL;
using NoSun.Models;

namespace NoSun.Controllers
{
    public class ArmorsController : Controller
    {
        private RPGContext db = new RPGContext();

        // GET: Armors
        public ActionResult Index()
        {
            return View(db.Armors.ToList());
        }

        // GET: Armors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armor armor = db.Armors.Find(id);
            if (armor == null)
            {
                return HttpNotFound();
            }
            return View(armor);
        }

        // GET: Armors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Armors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Armor armor)
        {
            if (ModelState.IsValid)
            {
                db.Armors.Add(armor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(armor);
        }

        // GET: Armors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armor armor = db.Armors.Find(id);
            if (armor == null)
            {
                return HttpNotFound();
            }
            return View(armor);
        }

        // POST: Armors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArmorId,Name,Atk,Def,Spd")] Armor armor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(armor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(armor);
        }

        // GET: Armors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armor armor = db.Armors.Find(id);
            if (armor == null)
            {
                return HttpNotFound();
            }
            return View(armor);
        }

        // POST: Armors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Armor armor = db.Armors.Find(id);
            db.Armors.Remove(armor);
            db.SaveChanges();
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
