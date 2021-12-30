using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webtest.Models;

namespace webtest.Controllers
{
    public class TrainingStaffController : Controller
    {
        TrainingContext db = new TrainingContext();
        // GET: TrainingStaff
        public ActionResult Index()
        {
            var list = db.TrainingStaffs.ToList<TrainingStaff>();
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
        public ActionResult Create([Bind(Include = "training_id,training_name,day_of_birth,phone_number,email_address,local_address,account_id")] TrainingStaff trainingStaff)
        {
            if (ModelState.IsValid)
            {
                db.TrainingStaffs.Add(trainingStaff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainingStaff);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            TrainingStaff trainingStaff = db.TrainingStaffs.Find(id);
            return View(trainingStaff);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "training_id,training_name,day_of_birth,phone_number,email_address,local_address,account_id")] TrainingStaff trainingStaff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingStaff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainingStaff);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            TrainingStaff trainingStaff = db.TrainingStaffs.Find(id);
            db.TrainingStaffs.Remove(trainingStaff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}