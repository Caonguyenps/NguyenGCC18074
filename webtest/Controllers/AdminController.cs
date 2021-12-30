using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webtest.Models;

namespace webtest.Controllers
{
    public class AdminController : Controller
    {
        TrainingContext db = new TrainingContext();
        // GET: Admin
        public ActionResult Index()
        {
            var list = db.Admins.ToList<Admin>();
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
        public ActionResult Create([Bind(Include = "admin_id,admin_name,day_of_birth,phone_number,email_address,local_address,account_id")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Admin admin = db.Admins.Find(id);
            return View(admin);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "admin_id,admin_name,day_of_birth,phone_number,email_address,local_address")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}