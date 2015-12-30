using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebForTraining.Database;
using WebForTraining.Models;

namespace WebForTraining.Controllers
{
    public class ModulesController : Controller
    {
        private string GetSession() { return Session["SessionID"].ToString(); }
        private int GetID() { return int.Parse(Session["UserID"].ToString()); }
        private string GetUserName() { return Session["Username"].ToString(); }

        private bool CheckSession()
        {
            if (Session["SessionID"] == null) { return false; }
            else
            {
                var ActiveSession = Login.getUserSessions()
                    .Where(p => p.isActive && p.sessionID == Guid.Parse(Session["SessionID"].ToString())).FirstOrDefault();
                if (ActiveSession == null) { return false; }
                else
                    return true;
            }
        }
        // GET: Modules
        public ActionResult Index()
        {
            if (!CheckSession())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        public ActionResult Register()
        {
            if (!CheckSession())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        public ActionResult Dispatch()
        {
            if (!CheckSession())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}