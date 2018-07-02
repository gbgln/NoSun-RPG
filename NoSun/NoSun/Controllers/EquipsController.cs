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
    public class EquipsController : Controller
    {
        private RPGContext db = new RPGContext();

        // GET: Equips
        public ActionResult Index()
        {
            return View(db.Equips.ToList());
        }

        // GET: Equips/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equip equip = db.Equips.Find(id);
            if (equip == null)
            {
                return HttpNotFound();
            }
            return View(equip);
        }

        // GET: Equips/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Equip equip)
        {
            if (ModelState.IsValid)
            {
                db.Equips.Add(equip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equip);
        }

        // GET: Equips/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equip equip = db.Equips.Find(id);
            if (equip == null)
            {
                return HttpNotFound();
            }
            return View(equip);
        }

        // POST: Equips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipId,Name,Atk,Def,Spd")] Equip equip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equip);
        }

        // GET: Equips/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equip equip = db.Equips.Find(id);
            if (equip == null)
            {
                return HttpNotFound();
            }
            return View(equip);
        }

        // POST: Equips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equip equip = db.Equips.Find(id);
            db.Equips.Remove(equip);
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
