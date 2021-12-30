using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webtest.Models;

namespace webtest.Controllers
{
    public class CategoryController : Controller
    {
        TrainingContext db = new TrainingContext();
        // GET: Category
        public ActionResult Index()
        {
            var list = db.Categories.ToList<Category>();
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
        public ActionResult Create([Bind(Include = "cat_id,cat_name,descriptions")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }



        [HttpGet]
        public ActionResult Edit(String id)
        {
            Category category = db.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "cat_id,cat_name,descriptions")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }




        [HttpGet]
        public ActionResult Delete(string id)

        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}