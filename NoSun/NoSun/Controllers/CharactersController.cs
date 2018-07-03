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
    public class CharactersController : Controller
    {
        private RPGContext db = new RPGContext();

        // GET: Characters
        public ActionResult Index()
        {
            var characters = db.Characters.Include(c => c._Armor).Include(c => c._Equip).Include(c => c._Race).Include(c => c._Weapon);
            return View(characters.ToList());
        }

        // GET: Characters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            ViewBag.ArmorID = new SelectList(db.Armors, "ArmorId", "ArmorToString");
            ViewBag.EquipID = new SelectList(db.Equips, "EquipId", "EquipToString");
            ViewBag.RaceID = new SelectList(db.Races, "RaceId", "RaceToString");
            ViewBag.WeaponID = new SelectList(db.Weapons, "WeaponId", "WeaponToString");
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Character character)
        {
            if (ModelState.IsValid)
            {
                db.Characters.Add(character);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArmorID = new SelectList(db.Armors, "ArmorId", "ArmorToString", character.ArmorID);
            ViewBag.EquipID = new SelectList(db.Equips, "EquipId", "EquipToString", character.EquipID);
            ViewBag.RaceID = new SelectList(db.Races, "RaceId", "RaceToString", character.RaceID);
            ViewBag.WeaponID = new SelectList(db.Weapons, "WeaponId", "WeaponToString", character.WeaponID);
            return View(character);
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArmorID = new SelectList(db.Armors, "ArmorId", "Name", character.ArmorID);
            ViewBag.EquipID = new SelectList(db.Equips, "EquipId", "Name", character.EquipID);
            ViewBag.RaceID = new SelectList(db.Races, "RaceId", "Name", character.RaceID);
            ViewBag.WeaponID = new SelectList(db.Weapons, "WeaponId", "Name", character.WeaponID);
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonagemId,Name,Atk,Def,Spd,Hp,RaceID,ArmorID,WeaponID,EquipID")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Entry(character).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArmorID = new SelectList(db.Armors, "ArmorId", "Name", character.ArmorID);
            ViewBag.EquipID = new SelectList(db.Equips, "EquipId", "Name", character.EquipID);
            ViewBag.RaceID = new SelectList(db.Races, "RaceId", "Name", character.RaceID);
            ViewBag.WeaponID = new SelectList(db.Weapons, "WeaponId", "Name", character.WeaponID);
            return View(character);
        }

        // GET: Characters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Character character = db.Characters.Find(id);
            db.Characters.Remove(character);
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
