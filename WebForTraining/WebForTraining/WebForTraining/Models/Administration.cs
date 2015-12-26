﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebForTraining.Database;
using System.Threading;
using System.Security.Claims;
using System.Security.Permissions;

namespace WebForTraining.Models
{
    public class Administration
    {
        #region UsersGroup
        public static ClsReturnValues setUsersGroup(ClsUserGroups obj, Guid SessionID)
        {
            ClsReturnValues lst = new ClsReturnValues();

            using (var db = new tdoEntities())
            {

                lst = db.uspAddEditUserGroups(obj.userGroupID, obj.groupName, obj.description ?? "", obj.createdByID, SessionID).FirstOrDefault();
            }
            return lst;
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public static List<ClsUserGroups> getUsersGroup()
        {
            List<ClsUserGroups> lst = new List<ClsUserGroups>();
            using (var db = new tdoEntities())
            {
                lst = db.uspGetUserGroups().ToList<ClsUserGroups>();
            }
            return lst;
        }

        public static ClsReturnValues delUsersGroup(int usersGroupId)
        {
            ClsReturnValues lst = new ClsReturnValues();
            using (var db = new tdoEntities())
            {
                lst = db.uspDelUsergroup(usersGroupId).FirstOrDefault();
            }
            return lst;
        }

        #endregion

        #region users

        public static ClsReturnValues setUsers(ClsUsers obj)
        {
            //password encryption happens here
            obj.password = Security.Encrypt(obj.password);

            ClsReturnValues lst = new ClsReturnValues();
            using (var db = new tdoEntities())
            {

                lst = db.uspAddEditUsers(obj.userID, obj.userGroupID, obj.userName, obj.password, obj.password, obj.passwordCanExpire, obj.passwordExpiryDate, obj.isLocked, obj.loginAttempts, obj.lastLoginDate, obj.theme, obj.resetPassword, obj.createdByID, obj.sessionID).FirstOrDefault();
            }
            return lst;
        }

        public static List<ClsUsers> getUsers()
        {
            List<ClsUsers> lst = new List<ClsUsers>();
            using (var db = new tdoEntities())
            {
                lst = db.uspGetUsers().ToList<ClsUsers>();
            }
            return lst;
        }

        public static ClsReturnValues delUsers(int userID)
        {
            ClsReturnValues lst = new ClsReturnValues();
            using (var db = new tdoEntities())
            {
                lst = db.uspDelUsers(userID).FirstOrDefault();
            }
            return lst;
        }

        #endregion users

        #region CargoType
        public static ClsReturnValues setCargoType(ClsCargoType obj, Guid SessionID)
        {
            ClsReturnValues lst = new ClsReturnValues();

            using (var db = new tdoEntities())
            {

                lst = db.uspAddEditCargoType(obj.cargoTypeID, obj.cargoTypeName, obj.createdByID, SessionID).FirstOrDefault();
            }
            return lst;
        }

        public static List<ClsCargoType> getCargoType(int cargoTypeID)
        {
            List<ClsCargoType> lst = new List<ClsCargoType>();
            using (var db = new tdoEntities())
            {
                lst = db.uspGetCargoType(cargoTypeID).ToList<ClsCargoType>();
            }
            return lst;
        }

        //public static ClsReturnValues delCargoType(int cargoTypeID)
        //{
        //    ClsReturnValues lst = new ClsReturnValues();
        //    using (var db = new tdoEntities())
        //    {
        //        lst = db.uspDelCargoType(cargoTypeID).FirstOrDefault();
        //    }
        //    return lst;
        //}

        #endregion

        public static ClsReturnValues changePassword(int userID, string oldPassword, string newPassword)
        {
            newPassword = Security.Encrypt(newPassword);
            oldPassword = Security.Encrypt(oldPassword);
            ClsReturnValues lst = new ClsReturnValues();
            using (var db = new tdoEntities())
            {
                lst = db.uspChangePassword(userID, oldPassword, newPassword).FirstOrDefault();
            }
            return lst;
        }
    }
}