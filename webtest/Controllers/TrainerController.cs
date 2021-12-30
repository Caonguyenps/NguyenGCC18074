using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webtest.Models;

namespace webtest.Controllers
{
    public class TrainerController : Controller
    {
        TrainingContext db = new TrainingContext();
        // GET: Trainer
        public ActionResult Index()
        {
            var list = db.Trainers.ToList<Trainer>();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["state"].ToString() != "1")
            {
                return RedirectToAction("About", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "trainer_id,trainer_name,education,external_or_internal,day_of_birth,phone_number,email_address,local_address,accout_id")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Trainers.Add(trainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainer);
        }

        [HttpGet]
        public  ActionResult Edit(int id)
        {
            Trainer trainer = db.Trainers.Find(id);
            return View(trainer);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "trainer_id,trainer_name,education,external_or_internal,day_of_birth,phone_number,email_address,local_address,accout_id")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainer);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Trainer trainer = db.Trainers.Find(id);
            db.Trainers.Remove(trainer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}