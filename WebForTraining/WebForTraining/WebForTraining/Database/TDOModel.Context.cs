﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebForTraining.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class tdoEntities : DbContext
    {
        public tdoEntities()
            : base("name=tdoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<ClsReturnValues> uspAddEditCargoType(Nullable<int> cargoTypeID, string cargoTypeName, Nullable<int> createdByID, Nullable<System.Guid> sessionID)
        {
            var cargoTypeIDParameter = cargoTypeID.HasValue ?
                new ObjectParameter("cargoTypeID", cargoTypeID) :
                new ObjectParameter("cargoTypeID", typeof(int));
    
            var cargoTypeNameParameter = cargoTypeName != null ?
                new ObjectParameter("cargoTypeName", cargoTypeName) :
                new ObjectParameter("cargoTypeName", typeof(string));
    
            var createdByIDParameter = createdByID.HasValue ?
                new ObjectParameter("createdByID", createdByID) :
                new ObjectParameter("createdByID", typeof(int));
    
            var sessionIDParameter = sessionID.HasValue ?
                new ObjectParameter("sessionID", sessionID) :
                new ObjectParameter("sessionID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ClsReturnValues>("uspAddEditCargoType", cargoTypeIDParameter, cargoTypeNameParameter, createdByIDParameter, sessionIDParameter);
        }
    
        public virtual ObjectResult<ClsCargoType> uspGetCargoType(Nullable<int> cargoTypeID)
        {
            var cargoTypeIDParameter = cargoTypeID.HasValue ?
                new ObjectParameter("cargoTypeID", cargoTypeID) :
                new ObjectParameter("cargoTypeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ClsCargoType>("uspGetCargoType", cargoTypeIDParameter);
        }
    
        public virtual ObjectResult<ClsReturnValues> uspAddEditUsers(Nullable<int> userID, Nullable<int> userGroupID, string userName, string password, string salt, Nullable<bool> passwordCanExpire, Nullable<System.DateTime> passwordExpiryDate, Nullable<bool> isLocked, Nullable<int> loginAttempts, Nullable<System.DateTime> lastLoginDate, string theme, Nullable<bool> resetPassword, Nullable<int> createdByID, Nullable<System.Guid> sessionID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var userGroupIDParameter = userGroupID.HasValue ?
                new ObjectParameter("userGroupID", userGroupID) :
                new ObjectParameter("userGroupID", typeof(int));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("userName", userName) :
                new ObjectParameter("userName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var saltParameter = salt != null ?
                new ObjectParameter("salt", salt) :
                new ObjectParameter("salt", typeof(string));
    
            var passwordCanExpireParameter = passwordCanExpire.HasValue ?
                new ObjectParameter("passwordCanExpire", passwordCanExpire) :
                new ObjectParameter("passwordCanExpire", typeof(bool));
    
            var passwordExpiryDateParameter = passwordExpiryDate.HasValue ?
                new ObjectParameter("passwordExpiryDate", passwordExpiryDate) :
                new ObjectParameter("passwordExpiryDate", typeof(System.DateTime));
    
            var isLockedParameter = isLocked.HasValue ?
                new ObjectParameter("isLocked", isLocked) :
                new ObjectParameter("isLocked", typeof(bool));
    
            var loginAttemptsParameter = loginAttempts.HasValue ?
                new ObjectParameter("loginAttempts", loginAttempts) :
                new ObjectParameter("loginAttempts", typeof(int));
    
            var lastLoginDateParameter = lastLoginDate.HasValue ?
                new ObjectParameter("lastLoginDate", lastLoginDate) :
                new ObjectParameter("lastLoginDate", typeof(System.DateTime));
    
            var themeParameter = theme != null ?
                new ObjectParameter("theme", theme) :
                new ObjectParameter("theme", typeof(string));
    
            var resetPasswordParameter = resetPassword.HasValue ?
                new ObjectParameter("resetPassword", resetPassword) :
                new ObjectParameter("resetPassword", typeof(bool));
    
            var createdByIDParameter = createdByID.HasValue ?
                new ObjectParameter("createdByID", createdByID) :
                new ObjectParameter("createdByID", typeof(int));
    
            var sessionIDParameter = sessionID.HasValue ?
                new ObjectParameter("sessionID", sessionID) :
                new ObjectParameter("sessionID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ClsReturnValues>("uspAddEditUsers", userIDParameter, userGroupIDParameter, userNameParameter, passwordParameter, saltParameter, passwordCanExpireParameter, passwordExpiryDateParameter, isLockedParameter, loginAttemptsParameter, lastLoginDateParameter, themeParameter, resetPasswordParameter, createdByIDParameter, sessionIDParameter);
        }
    
        public virtual ObjectResult<ClsReturnValues> uspAddEditUserSessionHistory(Nullable<System.Guid> sessionID, Nullable<int> userID, Nullable<System.DateTime> logoutDate, Nullable<bool> isActive, string deviceType, string deviceName, string browser)
        {
            var sessionIDParameter = sessionID.HasValue ?
                new ObjectParameter("sessionID", sessionID) :
                new ObjectParameter("sessionID", typeof(System.Guid));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var logoutDateParameter = logoutDate.HasValue ?
                new ObjectParameter("logoutDate", logoutDate) :
                new ObjectParameter("logoutDate", typeof(System.DateTime));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("isActive", isActive) :
                new ObjectParameter("isActive", typeof(bool));
    
            var deviceTypeParameter = deviceType != null ?
                new ObjectParameter("deviceType", deviceType) :
                new ObjectParameter("deviceType", typeof(string));
    
            var deviceNameParameter = deviceName != null ?
                new ObjectParameter("deviceName", deviceName) :
                new ObjectParameter("deviceName", typeof(string));
    
            var browserParameter = browser != null ?
                new ObjectParameter("browser", browser) :
                new ObjectParameter("browser", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ClsReturnValues>("uspAddEditUserSessionHistory", sessionIDParameter, userIDParameter, logoutDateParameter, isActiveParameter, deviceTypeParameter, deviceNameParameter, browserParameter);
        }
    
        public virtual ObjectResult<ClsReturnValues> uspAddEditUserSessions(Nullable<System.Guid> sessionID, Nullable<int> userID, Nullable<bool> isActive, string deviceType, string deviceName, string browser)
        {
            var sessionIDParameter = sessionID.HasValue ?
                new ObjectParameter("sessionID", sessionID) :
                new ObjectParameter("sessionID", typeof(System.Guid));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("isActive", isActive) :
                new ObjectParameter("isActive", typeof(bool));
    
            var deviceTypeParameter = deviceType != null ?
                new ObjectParameter("deviceType", deviceType) :
                new ObjectParameter("deviceType", typeof(string));
    
            var deviceNameParameter = deviceName != null ?
                new ObjectParameter("deviceName", deviceName) :
                new ObjectParameter("deviceName", typeof(string));
    
            var browserParameter = browser != null ?
                new ObjectParameter("browser", browser) :
                new ObjectParameter("browser", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ClsReturnValues>("uspAddEditUserSessions", sessionIDParameter, userIDParameter, isActiveParameter, deviceTypeParameter, deviceNameParameter, browserParameter);
        }
    
        public virtual ObjectResult<ClsReturnValues> uspDelUserSession(Nullable<System.Guid> sessionID, Nullable<int> userID)
        {
            var sessionIDParameter = sessionID.HasValue ?
                new ObjectParameter("sessionID", sessionID) :
                new ObjectParameter("sessionID", typeof(System.Guid));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ClsReturnValues>("uspDelUserSession", sessionIDParameter, userIDParameter);
        }
    
        public virtual ObjectResult<ClsUsers> uspGetUsers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ClsUsers>("uspGetUsers");
        }
    
        public virtual ObjectResult<ClsUserSessionHistory> uspGetUserSessionHistory()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ClsUserSessionHistory>("uspGetUserSessionHistory");
        }
    
        public virtual ObjectResult<ClsUserSessions> uspGetUserSessions()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ClsUserSessions>("uspGetUserSessions");
        }
    
        public virtual ObjectResult<ClsReturnValues> uspUserAuthentication(string userName, string password, string deviceType, string deviceName, string browser)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("userName", userName) :
                new ObjectParameter("userName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var deviceTypeParameter = deviceType != null ?
                new ObjectParameter("deviceType", deviceType) :
                new ObjectParameter("deviceType", typeof(string));
    
            var deviceNameParameter = deviceName != null ?
                new ObjectParameter("deviceName", deviceName) :
                new ObjectParameter("deviceName", typeof(string));
    
            var browserParameter = browser != null ?
                new ObjectParameter("browser", browser) :
                new ObjectParameter("browser", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ClsReturnValues>("uspUserAuthentication", userNameParameter, passwordParameter, deviceTypeParameter, deviceNameParameter, browserParameter);
        }
    
        public virtual ObjectResult<ClsUserGroups> uspGetUserGroups()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ClsUserGroups>("uspGetUserGroups");
        }
    
        public virtual ObjectResult<ClsUserDisplay> uspGetUserDisplay(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ClsUserDisplay>("uspGetUserDisplay", userIDParameter);
        }
    
        public virtual ObjectResult<ClsReturnValues> uspAddEditUserGroups(Nullable<int> userGroupID, string groupName, string description, Nullable<int> createdByID, Nullable<System.Guid> sessionID)
        {
            var userGroupIDParameter = userGroupID.HasValue ?
                new ObjectParameter("userGroupID", userGroupID) :
                new ObjectParameter("userGroupID", typeof(int));
    
            var groupNameParameter = groupName != null ?
                new ObjectParameter("groupName", groupName) :
                new ObjectParameter("groupName", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var createdByIDParameter = createdByID.HasValue ?
                new ObjectParameter("createdByID", createdByID) :
                new ObjectParameter("createdByID", typeof(int));
    
            var sessionIDParameter = sessionID.HasValue ?
                new ObjectParameter("sessionID", sessionID) :
                new ObjectParameter("sessionID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ClsReturnValues>("uspAddEditUserGroups", userGroupIDParameter, groupNameParameter, descriptionParameter, createdByIDParameter, sessionIDParameter);
        }
    
        public virtual ObjectResult<ClsReturnValues> uspDelUsergroup(Nullable<int> userGroupID)
        {
            var userGroupIDParameter = userGroupID.HasValue ?
                new ObjectParameter("userGroupID", userGroupID) :
                new ObjectParameter("userGroupID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ClsReturnValues>("uspDelUsergroup", userGroupIDParameter);
        }
    
        public virtual ObjectResult<ClsReturnValues> uspDelUsers(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ClsReturnValues>("uspDelUsers", userIDParameter);
        }
    
        public virtual ObjectResult<ClsReturnValues> uspChangePassword(Nullable<int> userID, string oldPassword, string newPassword)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var oldPasswordParameter = oldPassword != null ?
                new ObjectParameter("oldPassword", oldPassword) :
                new ObjectParameter("oldPassword", typeof(string));
    
            var newPasswordParameter = newPassword != null ?
                new ObjectParameter("newPassword", newPassword) :
                new ObjectParameter("newPassword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ClsReturnValues>("uspChangePassword", userIDParameter, oldPasswordParameter, newPasswordParameter);
        }
    }
}
