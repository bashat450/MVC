using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMVCApps.Models
{
    public class InsertEmployeeModel
    {
        public string FullName { get; set; }
        public int Salary { get; set; }
        public string Country { get; set; }
        public string EmailId { get; set; }
        public DateTime CurrentDate { get; set; }
        public int DepId { get; set; }
        public string JobTitle { get; set; }

    }
}