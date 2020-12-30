using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class DBClass
    {
        MyDataBaseEntities db = new MyDataBaseEntities();
        /// <summary>
        /// Get the list of all employees;Object is Employee
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployees()
        {
            Console.Clear();
            return db.Employees.ToList();
        }
        /// <summary>
        /// Get a single employee; object is Employee
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Employee GetEmployee(int ID)
        {
            Employee employee = new Employee();  
            var list = GetEmployees();
            foreach(var emp in list)
            {
                if (emp.ID == ID)
                    employee= emp;
            }
            return employee;
        }
        /// <summary>
        /// Adds an Employee object to the DB
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool AddEmployee(Employee employee)
        {
            bool result = false;
            if(employee!=null)
            {
                List<Employee> list=GetEmployees();
                foreach(var emp in list)
                {
                    if(emp.ID==employee.ID)
                    {
                        Console.WriteLine("Employee already exists");
                        return result;
                    }
                }
                db.Employees.Add(employee);
                db.SaveChanges();
                result = true;
            }
            return result;
        }
        /// <summary>
        /// Removes an Employee object from the DB
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DeleteEmployee(int ID)
        {
            bool result=false;
            Employee employee = null;
            var list = GetEmployees();
            foreach (var emp in list)
            {
                if (emp.ID == ID)
                    employee = emp;
            }
            if (employee!=null)
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
                result = true;
            }
            return result;
        }
        /// <summary>
        /// Updates an employee information except ID(primary key)
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool UpdateEmployee(Employee employee)
        {
            bool result = false;
            Employee emp = null;
            var list = GetEmployees();
            foreach (var e in list)
            {
                if (e.ID == employee.ID)
                    emp = e;
            }
            if (emp != null)
            {
                emp.EmployeeName = employee.EmployeeName;
                emp.EmployeeAge = employee.EmployeeAge;
                emp.EmplyeeMailID = employee.EmplyeeMailID;
                db.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
