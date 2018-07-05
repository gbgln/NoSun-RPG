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
    public class RewardsController : Controller
    {
        private RPGContext db = new RPGContext();

        // GET: Rewards
        public ActionResult Index()
        {
            var rewards = db.Rewards.Include(i => i._Region).Include(i => i._NPC);
            return View(rewards.ToList());
        }

        // GET: Rewards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reward reward = db.Rewards.Find(id);
            if (reward == null)
            {
                return HttpNotFound();
            }
            return View(reward);
        }

        // GET: Rewards/Create
        public ActionResult Create()
        {
            List<Region> lstRegion = db.Regions.ToList();
            lstRegion.Insert(0, new Region { RegionID = 0, RegionName = "--Select Region--" });

            List<NPC> lstNPC = new List<NPC>();
            ViewBag.RegionId = new SelectList(lstRegion, "RegionID", "RegionName");
            ViewBag.NPCId = new SelectList(lstNPC, "NPCID", "NPCName");
            return View();
        }

        public JsonResult GetNPCsByRegionId(int id)
        {
            List<NPC> NPCs = new List<NPC>();
            if (id > 0)
            {
                NPCs = db.NPCs.Where(p => p.RegionID == id).ToList();

            }
            else
            {
                NPCs.Insert(0, new NPC { NPCID = 0, NPCName = "--Select a region first--" });
            }
            var result = (from r in NPCs
                          select new
                          {
                              id = r.NPCID,
                              name = r.NPCName
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // POST: Rewards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reward reward)
        {
            if (ModelState.IsValid)
            {
                db.Rewards.Add(reward);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegionId = new SelectList(db.Regions, "RegionID", "RegionName", reward.RegionID);
            ViewBag.NPCId = new SelectList(db.NPCs, "NPCID", "NPCName", reward.NPCID);
            return View(reward);
        }

        // GET: Rewards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reward reward = db.Rewards.Find(id);
            if (reward == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionId = new SelectList(db.Regions, "RegionID", "RegionName", reward.RegionID);
            ViewBag.NPCId = new SelectList(db.NPCs, "NPCID", "NPCName", reward.NPCID);
            return View(reward);
        }

        // POST: Rewards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reward reward)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reward).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegionId = new SelectList(db.Regions, "RegionID", "RegionName", reward.RegionID);
            ViewBag.NPCId = new SelectList(db.NPCs, "NPCID", "NPCName", reward.NPCID);
            return View(reward);
        }

        // GET: Rewards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reward reward = db.Rewards.Find(id);
            if (reward == null)
            {
                return HttpNotFound();
            }
            return View(reward);
        }

        // POST: Rewards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reward reward = db.Rewards.Find(id);
            db.Rewards.Remove(reward);
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
