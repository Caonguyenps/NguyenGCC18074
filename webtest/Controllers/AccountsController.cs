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
    public class AccountsController : Controller
    {
        private TrainingContext db = new TrainingContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "username, password")] Account account)
        {
            TrainingContext db = new TrainingContext();
            Account acc = new Account();
            acc = db.Accounts.Where(p => p.username == account.username && p.password == account.password).FirstOrDefault();
            if (acc != null)
            {
                Session["username"] = acc.username;
                Session["state"] = acc.state;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Accounts");
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Index()
        {
            var list = db.Accounts.ToList<Account>();
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
        public ActionResult Create([Bind(Include = "accout_id,username,password,state")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Account account = db.Accounts.Find(id);
            return View(account);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "accout_id,username,password,state")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
