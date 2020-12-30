using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
    public class Program
    {
        public static DBClass dbObj = new DBClass();
        public static void Main(string[] args)
        {
            Console.WriteLine("this is beginning of my console");            
            while(true)
            {
                Console.WriteLine("select your choice:");
                Console.WriteLine("\n1. Get all employess\n 2. Get a single employee\n 3.Add an employee\n 4.Remove an employee\n 5.Update an employee Info\n Any key to exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        GetEmployees();
                        break;
                    case "2":
                        GetEmployee();
                        break;
                    case "3":
                        AddEmployee();
                        break;
                    case "4":
                        DeleteEmployee();
                        break;
                    case "5":
                        UpdateEmployee();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static void GetEmployees()
        {            
            var list = dbObj.GetEmployees();            
            if (list.Count != 0)
            {
                Console.WriteLine("FORMAT: emp.ID - emp.EmployeeName - emp.EmployeeAge- emp.EmplyeeMailID");
                foreach (var emp in list)
                {
                    Console.WriteLine(emp.ID + "-" + emp.EmployeeName + "-" + emp.EmployeeAge + "-" + emp.EmplyeeMailID);
                }
            }
            else
                Console.WriteLine("There are no employees");
        }
        private static void GetEmployee()
        {
            Console.WriteLine("enter employee id");
            int id = int.Parse(Console.ReadLine());
            Employee emp = new Employee();
            emp = dbObj.GetEmployee(id);
            if (emp != null)
                Console.WriteLine(emp.ID + "-" + emp.EmployeeName + "-" + emp.EmployeeAge + "-" + emp.EmplyeeMailID);
            else
                Console.WriteLine("Employee not found");
        }
        private static void AddEmployee()
        {
            Console.WriteLine("enter employee id, Employee name, Employee Age, Employee Email");
            int id = int.Parse(Console.ReadLine());
            string Name = Console.ReadLine();
            int Age  = int.Parse(Console.ReadLine());
            string mail = Console.ReadLine();
            Employee emp = new Employee();
            emp.ID = id;emp.EmployeeName = Name;emp.EmployeeAge = Age;emp.EmplyeeMailID = mail;
            bool result = dbObj.AddEmployee(emp);
            if (result)
                Console.WriteLine("employee added successfully");
            else
                Console.WriteLine("Please check employee details");
        }
        private static void DeleteEmployee()
        {
            Console.WriteLine("enter employee id");
            int id = int.Parse(Console.ReadLine());
            bool result = dbObj.DeleteEmployee(id);
            if (result)
                Console.WriteLine("Employee deleted successfully");
            else
                Console.WriteLine("Employee not found");              
        }
        private static void UpdateEmployee()
        {
            Console.WriteLine("enter employee id, Employee name, Employee Age, Employee Email");
            int id = int.Parse(Console.ReadLine());
            string Name = Console.ReadLine();
            int Age = int.Parse(Console.ReadLine());
            string mail = Console.ReadLine();
            Employee emp = new Employee();
            emp.ID = id; emp.EmployeeName = Name; emp.EmployeeAge = Age; emp.EmplyeeMailID = mail;
            bool result = dbObj.UpdateEmployee(emp);
            if (result)
                Console.WriteLine("Employee Updated successfully");
            else
                Console.WriteLine("Employee not found");
        }
    }
}
