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

namespace Web.Mahedee.net.Controllers
{
    public class NPCsController : Controller
    {
        private RPGContext db = new RPGContext();

        // GET: NPCs
        public ActionResult Index()
        {
            var NPCs = db.NPCs.Include(p => p._Region);
            return View(NPCs.ToList());
        }

        // GET: NPCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NPC NPC = db.NPCs.Find(id);
            if (NPC == null)
            {
                return HttpNotFound();
            }
            return View(NPC);
        }

        // GET: NPCs/Create
        public ActionResult Create()
        {
            ViewBag.RegionId = new SelectList(db.Regions, "RegionID", "RegionName");
            return View();
        }

        public ActionResult GetNPCsByRegionId(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            List<NPC> NPCs = db.NPCs.Where(p => p.RegionID == id).ToList();
            if (NPCs == null)
            {
                return HttpNotFound();
            }
            return Json(NPCs, JsonRequestBehavior.AllowGet);
        }

        // POST: NPCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NPC NPC)
        {
            if (ModelState.IsValid)
            {
                db.NPCs.Add(NPC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegionId = new SelectList(db.Regions, "RegionID", "RegionName", NPC.RegionID);
            return View(NPC);
        }

        // GET: NPCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NPC NPC = db.NPCs.Find(id);
            if (NPC == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionId = new SelectList(db.Regions, "RegionID", "RegionName", NPC.RegionID);
            return View(NPC);
        }

        // POST: NPCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NPC NPC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(NPC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegionId = new SelectList(db.Regions, "RegionID", "RegionName", NPC.RegionID);
            return View(NPC);
        }

        // GET: NPCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NPC NPC = db.NPCs.Find(id);
            if (NPC == null)
            {
                return HttpNotFound();
            }
            return View(NPC);
        }

        // POST: NPCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NPC NPC = db.NPCs.Find(id);
            db.NPCs.Remove(NPC);
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
