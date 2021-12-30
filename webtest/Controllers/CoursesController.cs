using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webtest.Models;

namespace webtest.Controllers
{
    public class CoursesController : Controller
    {
        private TrainingContext db = new TrainingContext();

        // GET: Courses
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Category).Include(c => c.Trainer);
            return View(courses.ToList());
        }
        // GET: Courses/Create
        public ActionResult Create()
        {
            if (Session["state"].ToString() != "2")
            {
                return RedirectToAction("About", "Home");
            }
            ViewBag.cat_id = new SelectList(db.Categories, "cat_id", "cat_name");
            ViewBag.trainer_id = new SelectList(db.Trainers, "trainer_id", "trainer_name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "course_id,course_name,course_toeic,desription,account_id,cat_id,trainer_id")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cat_id = new SelectList(db.Categories, "cat_id", "cat_name", course.cat_id);
            ViewBag.trainer_id = new SelectList(db.Trainers, "trainer_id", "trainer_name", course.trainer_id);
            return View(course);
        }
        public ActionResult Edit(string id)
        {
            Course course = db.Courses.Find(id);
            ViewBag.cat_id = new SelectList(db.Categories, "cat_id", "cat_name", course.cat_id);
            ViewBag.trainer_id = new SelectList(db.Trainers, "trainer_id", "trainer_name", course.trainer_id);
            return View(course);
        }

        
        [HttpPost]
        public ActionResult Edit([Bind(Include = "course_id,course_name,course_toeic,desription,account_id,cat_id,trainer_id")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cat_id = new SelectList(db.Categories, "cat_id", "cat_name", course.cat_id);
            ViewBag.trainer_id = new SelectList(db.Trainers, "trainer_id", "trainer_name", course.trainer_id);
            return View(course);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
