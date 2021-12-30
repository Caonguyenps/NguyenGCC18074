using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webtest.Models;

namespace webtest.Controllers
{
    public class TraineeController : Controller
    {
        TrainingContext db = new TrainingContext();
        // GET: Trainee
        public ActionResult Index()
        {
            var list = db.Trainees.ToList<Trainee>();
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
        public ActionResult Create([Bind(Include = "trainee_id,trainee_name,day_of_birth,phone_number,email_address,local_address,course_id,course_toiec,account_detail_id")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Trainees.Add(trainee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainee);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Trainee trainee = db.Trainees.Find(id);
            return View(trainee);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "trainee_id,trainee_name,day_of_birth,phone_number,email_address,local_address,course_id,course_toiec,account_detail_id")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainee);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Trainee trainee = db.Trainees.Find(id);
            db.Trainees.Remove(trainee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}