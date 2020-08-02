using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMVCApp.Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public string EmplyeeMailID { get; set; }
        public int EmployeeAge { get; set; }
    }
}