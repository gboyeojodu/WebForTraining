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
    
    public partial class ClsForms
    {
        public int formID { get; set; }
        public Nullable<int> menuItemID { get; set; }
        public string formName { get; set; }
        public string menuItemName { get; set; }
        public string formDescription { get; set; }
        public Nullable<System.DateTime> dateCreated { get; set; }
        public Nullable<int> createdByID { get; set; }
        public string username { get; set; }
        public Nullable<System.Guid> sessionID { get; set; }
    }
}
