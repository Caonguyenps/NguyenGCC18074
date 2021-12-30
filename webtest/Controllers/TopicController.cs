using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webtest.Models;

namespace webtest.Controllers
{
    public class TopicController : Controller
    {
        TrainingContext db = new TrainingContext();
        // GET: Topic
        public ActionResult Index()
        {
            var list = db.Topics.ToList<Topic>();
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
        public ActionResult Create([Bind(Include = "topic_id,topic_name,descriptions,course_id")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Topics.Add(topic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topic);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Topic topic = db.Topics.Find(id);
            return View(topic);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "topic_id,topic_name,descriptions,course_id")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topic);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Topic topic = db.Topics.Find(id);
            db.Topics.Remove(topic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}