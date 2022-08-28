using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace programs
{
    internal class Program
    {


        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>();

            int numberOfEmployees = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEmployees; i++)
            {
                string[] token = Console.ReadLine().Split();

                if (!departments.Any(d => d.DepartmentName == token[2]))
                {
                    departments.Add(new Department(token[2]));
                }

                departments.Find(d => d.DepartmentName == token[2]).AddNewEmployee(token[0], decimal.Parse(token[1]));

            }

            Department bestDepartment = departments.OrderByDescending(d => d.TotalSalaries / d.Employees.Count()).First();

            Console.WriteLine($"Highest Average Salary: {bestDepartment.DepartmentName}");


            var newlist = bestDepartment.Employees.OrderByDescending(e => e.Salary).ToList();

            foreach (var employee in newlist)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
            }


        }
    }
    class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public Employee(string name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }
    }

    class Department
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public decimal TotalSalaries { get; set; }

        public void AddNewEmployee(string empName, decimal empSalary)
        {
            this.TotalSalaries += empSalary;

            this.Employees.Add(new Employee(empName, empSalary));
        }

        public Department(string departmentName)
        {
            this.DepartmentName = departmentName;
        }
    }
}