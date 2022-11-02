using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string ReportID { get; set; }
        public bool IsActive { get; set; }
    }
}