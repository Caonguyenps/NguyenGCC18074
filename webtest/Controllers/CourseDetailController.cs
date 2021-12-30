using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webtest.Models;

namespace webtest.Controllers
{
    public class CourseDetailController : Controller
    {
        TrainingContext db = new TrainingContext();
        // GET: CourseDetail
        public ActionResult Index()
        {
            var list = db.CourseDetails.ToList<CourseDetail>();
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
        public ActionResult Create([Bind(Include = "course_detail_id,course_id,trainee_id")] CourseDetail courseDetail)
        {
            if (ModelState.IsValid)
            {
                db.CourseDetails.Add(courseDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseDetail);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CourseDetail courseDetail = db.CourseDetails.Find(id);
            return View(courseDetail);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "course_detail_id,course_id,trainee_id")] CourseDetail courseDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseDetail);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            CourseDetail courseDetail = db.CourseDetails.Find(id);
            db.CourseDetails.Remove(courseDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}