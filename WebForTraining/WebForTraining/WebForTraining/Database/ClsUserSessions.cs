//------------------------------------------------------------------------------
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
    
    public partial class ClsUserSessions
    {
        public System.Guid sessionID { get; set; }
        public Nullable<int> userID { get; set; }
        public System.DateTime loginDate { get; set; }
        public System.DateTime logoutDate { get; set; }
        public bool isActive { get; set; }
        public string deviceType { get; set; }
        public string deviceName { get; set; }
        public string browser { get; set; }
        public string userName { get; set; }
    }
}
