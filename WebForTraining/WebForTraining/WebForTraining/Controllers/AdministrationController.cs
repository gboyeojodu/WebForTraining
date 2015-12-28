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
        public ActionResult changePassword()
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
        public JsonResult deleteUsersGroup(string ids)
        {
            string[] id_s = ids.Trim().Split(',');
            string message = "";
            List<ClsReturnValues> obj = new List<ClsReturnValues>();
            foreach (var id in id_s)
            {
                int _id = 0; try { _id = int.Parse(id.Trim()); }
                catch { }
                if (_id > 0)
                    obj.Add(Administration.delUsersGroup(_id));
            }

            bool isSuccess = obj.Count(p => p.IsSuccess == false) > 0 ? false : true;
            if (obj.Count(p => p.IsSuccess == true) > 1)
            {
                message = obj.Count(p => p.IsSuccess == true).ToString() + " records deleted";
            }
            else
            {
                message = obj.Count(p => p.IsSuccess == true).ToString() + " record deleted";
            }

            return Json(new { id = isSuccess ? 1 : 0, isSuccess = isSuccess ? 1 : 0, msg = message });
        }
        public JsonResult deleteUser(string ids)
        {
            string[] id_s = ids.Trim().Split(',');
            string message = "";
            List<ClsReturnValues> obj = new List<ClsReturnValues>();
            foreach (var id in id_s)
            {
                int _id = 0; try { _id = int.Parse(id.Trim()); }
                catch { }
                if (_id > 0)
                    obj.Add(Administration.delUsers(_id));
            }

            bool isSuccess = obj.Count(p => p.IsSuccess == false) > 0 ? false : true;
            if (obj.Count(p => p.IsSuccess == true) > 1)
            {
                message = obj.Count(p => p.IsSuccess == true).ToString() + " records deleted";
            }
            else
            {
                message = obj.Count(p => p.IsSuccess == true).ToString() + " record deleted";
            }

            return Json(new { id = isSuccess ? 1 : 0, isSuccess = isSuccess ? 1 : 0, msg = message });
        }
        public JsonResult setChangePassword(string userID, string oldPassword, string newPassword, string confirmNewPassword)
        {
            if (newPassword != confirmNewPassword)
            {
                return Json(new { id = 0, isSuccess = false, msg = "Confirm password not correct." });
            }
            int id = int.Parse(userID);
            
            ClsReturnValues k = Administration.changePassword(id, oldPassword, newPassword);
            return Json(new { id = k.ID, isSuccess = k.IsSuccess ?? false ? 1 : 0, msg = k.Response });
        }

        #region CargoType

        public ActionResult getCargoTypeDisplay()
        {
            if (!CheckSession())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        public ActionResult AddEditCargoType()
        {
            if (!CheckSession())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        public JsonResult setCargoType(string cargoTypeID, string cargoTypeName)
        {

            if (cargoTypeID == "") { cargoTypeID = "0"; }

            Guid Session = new Guid(GetSession()); //do not hard code session ID and createdbyID
            int _id = 0;
            try { _id = int.Parse(cargoTypeID.Trim()); }
            catch { }
            ClsCargoType obj = new ClsCargoType()
            {
                cargoTypeID = _id,
                cargoTypeName = cargoTypeName,
                createdByID = GetID(),
                sessionID = Session
            };
            ClsReturnValues k = Administration.setCargoType(obj, Session);
            return Json(new { id = k.ID, isSuccess = k.IsSuccess ?? false ? 1 : 0, msg = k.Response });
        }

        public JsonResult deleteCargoType(string ids)
        {
            string[] id_s = ids.Trim().Split(',');
            string message = "";
            List<ClsReturnValues> obj = new List<ClsReturnValues>();
            foreach (var id in id_s)
            {
                int _id = 0; try { _id = int.Parse(id.Trim()); }
                catch { }
                if (_id > 0)
                    obj.Add(Administration.delCargoType(_id));
            }

            bool isSuccess = obj.Count(p => p.IsSuccess == false) > 0 ? false : true;
            if (obj.Count(p => p.IsSuccess == true) > 1)
            {
                message = obj.Count(p => p.IsSuccess == true).ToString() + " records deleted";
            }
            else
            {
                message = obj.Count(p => p.IsSuccess == true).ToString() + " record deleted";
            }

            return Json(new { id = isSuccess ? 1 : 0, isSuccess = isSuccess ? 1 : 0, msg = message });
        }

        #endregion

        #region TruckType

        public ActionResult getTruckTypeDisplay()
        {
            if (!CheckSession())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        public ActionResult AddEditTruckType()
        {
            if (!CheckSession())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        public JsonResult setTruckType(string truckTypeID, string truckTypeName)
        {

            if (truckTypeID == "") { truckTypeID = "0"; }

            Guid Session = new Guid(GetSession()); //do not hard code session ID and createdbyID
            int _id = 0;
            try { _id = int.Parse(truckTypeID.Trim()); }
            catch { }
            ClsTruckType obj = new ClsTruckType()
            {
                truckTypeID = _id,
                truckTypeName = truckTypeName,
                createdByID = GetID(),
                sessionID = Session
            };
            ClsReturnValues k = Administration.setTruckType(obj, Session);
            return Json(new { id = k.ID, isSuccess = k.IsSuccess ?? false ? 1 : 0, msg = k.Response });
        }

        public JsonResult deleteTruckType(string ids)
        {
            string[] id_s = ids.Trim().Split(',');
            string message = "";
            List<ClsReturnValues> obj = new List<ClsReturnValues>();
            foreach (var id in id_s)
            {
                int _id = 0; try { _id = int.Parse(id.Trim()); }
                catch { }
                if (_id > 0)
                    obj.Add(Administration.delTruckType(_id));
            }

            bool isSuccess = obj.Count(p => p.IsSuccess == false) > 0 ? false : true;
            if (obj.Count(p => p.IsSuccess == true) > 1)
            {
                message = obj.Count(p => p.IsSuccess == true).ToString() + " records deleted";
            }
            else
            {
                message = obj.Count(p => p.IsSuccess == true).ToString() + " record deleted";
            }

            return Json(new { id = isSuccess ? 1 : 0, isSuccess = isSuccess ? 1 : 0, msg = message });
        }

        #endregion

    }
}