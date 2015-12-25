using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebForTraining.Database;
using WebForTraining.Models;

namespace WebForTraining.Controllers
{
    public class AdministrationController : Controller
    {
        // GET: Administration
        private string GetSession() { return Session["SessionID"].ToString(); }
        private int GetID() { return int.Parse(Session["UserID"].ToString()); }
        private int GetCompanyID() { return int.Parse(Session["CompanyID"].ToString()); }


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
        public ActionResult Index()
        {
            if (!CheckSession())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        public ActionResult Setup()
        {
            if (!CheckSession())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        public ActionResult Settings()
        {
            if (!CheckSession())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        public ActionResult getUserGroupDisplay()
        {
            if (!CheckSession())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        public ActionResult getUserDisplay()
        {
            if (!CheckSession())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        public ActionResult AddEditUserGroup()
        {
            if (!CheckSession())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        public ActionResult AddEditUser()
        {
            if (!CheckSession())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        public JsonResult setUsersGroup(string userGroupID, string groupName, string description)
        {

            if (userGroupID == "") { userGroupID = "0"; }

            Guid Session = new Guid(GetSession()); //do not hard code session ID and createdbyID
            int _id = 0; 
            try { _id = int.Parse(userGroupID.Trim()); }
            catch { }
            ClsUserGroups obj = new ClsUserGroups()
            {
                userGroupID = _id,
                groupName = groupName,
                description = description,
                createdByID = GetID(),
                sessionID = Session
            };
            ClsReturnValues k = Administration.setUsersGroup(obj, Session);
            return Json(new { id = k.ID, isSuccess = k.IsSuccess ?? false ? 1 : 0, msg = k.Response });
        }
        [HttpPost]
        public JsonResult setUsers(string userID, string userGroupID, string userName, string Password, int isLocked, int resetPassword)
        {
            Guid Session = new Guid(GetSession());
            if (Password == "") Password = " ";
            int _id = 0; try { _id = int.Parse(userID.Trim()); }
            catch { }
            int _grIid = 0; try { _grIid = int.Parse(userGroupID.Trim()); }
            catch { }
            bool Locked = false; bool reset = false;
            if (isLocked == 1) Locked = true; if (resetPassword == 1) reset = true;
            ClsUsers obj = new ClsUsers()
            {
                userID = _id,
                userGroupID = _grIid,
                userName = userName.Trim(),
                resetPassword = reset,
                password = Password,
                isLocked = Locked,
                createdByID = GetID(),
                theme = "Default",
                sessionID = Session
            };
            ClsReturnValues k = Administration.setUsers(obj);
            return Json(new { id = k.ID, isSuccess = k.IsSuccess ?? false ? 1 : 0, msg = k.Response });
        }
    }
}