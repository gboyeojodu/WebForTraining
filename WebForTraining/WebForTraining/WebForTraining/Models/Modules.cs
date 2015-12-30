using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebForTraining.Database;
using System.Threading;
using System.Security.Claims;
using System.Security.Permissions;

namespace WebForTraining.Models
{
    public class Modules
    {
        public static ClsJobNumber getJobNumber()
        {
            ClsJobNumber lst = new ClsJobNumber();
            using (var db = new tdoEntities())
            {
                lst = db.uspGetJobNumber().FirstOrDefault();
            }
            return lst;
        }
    }
}