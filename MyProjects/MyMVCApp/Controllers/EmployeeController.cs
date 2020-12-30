using MyClassLibrary;
using MyMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCApp.Controllers
{
    public class EmployeeController : Controller
    {
        DBClass dbObject = new DBClass();
        [HttpGet]
        public ActionResult Employees()
        {
            
            var list = dbObject.GetEmployees().ToList();
            List<EmployeeModel> empList = new List<EmployeeModel>();
            foreach(var le in list)
            {
                EmployeeModel empModel = new EmployeeModel();
                empModel.ID = le.ID;
                empModel.EmployeeName = le.EmployeeName;
                empModel.EmployeeAge = le.EmployeeAge;
                empModel.EmplyeeMailID = le.EmplyeeMailID;
                empList.Add(empModel);
            }
            return View(empList);
        }
        [HttpGet]
        public ActionResult Employee(EmployeeModel employee)
        {
            var emp = dbObject.GetEmployee(employee.ID);
            employee.ID = emp.ID;
            employee.EmployeeName = emp.EmployeeName;
            employee.EmployeeAge = emp.EmployeeAge;
            employee.EmplyeeMailID = emp.EmplyeeMailID;
            return View(employee);
        }
        [HttpGet]
        public ActionResult AddEmployee(EmployeeModel employee)
        {            
            return View(employee);
        }
        [HttpPost]
        public ViewResult AddEmployee(EmployeeModel employee,int id)
        {
            Employee emp = new Employee();
            emp.ID = employee.ID;
            emp.EmployeeName = employee.EmployeeName;
            emp.EmployeeAge = employee.EmployeeAge;
            emp.EmplyeeMailID = employee.EmplyeeMailID;
            bool res=dbObject.AddEmployee(emp);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(EmployeeModel employee)
        {

            var emp = dbObject.GetEmployee(employee.ID);
            employee.ID = emp.ID;
            employee.EmployeeName = emp.EmployeeName;
            employee.EmployeeAge = emp.EmployeeAge;
            employee.EmplyeeMailID = emp.EmplyeeMailID;
            return View(employee);
        }
        [HttpPost]
        public ViewResult Edit(EmployeeModel employee,int id)
        {
            Employee emp = new Employee();
            emp.ID = employee.ID;
            emp.EmployeeName = employee.EmployeeName;
            emp.EmployeeAge = employee.EmployeeAge;
            emp.EmplyeeMailID = employee.EmplyeeMailID;
            bool res = dbObject.UpdateEmployee(emp);
            employee.EmployeeName = res.ToString();
            return View(employee);
        }
        [HttpGet]
        public ActionResult Delete(EmployeeModel employee)
        {
            var emp = dbObject.GetEmployee(employee.ID);
            employee.ID = emp.ID;
            employee.EmployeeName = emp.EmployeeName;
            employee.EmployeeAge = emp.EmployeeAge;
            employee.EmplyeeMailID = emp.EmplyeeMailID;
            return View(employee);
        }
        [HttpPost]
        public ViewResult Delete(EmployeeModel employee, int id)
        {            
            bool res = dbObject.DeleteEmployee(employee.ID);
            employee.EmployeeName = res.ToString();
            return View(employee);
        }
    }
}