﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSampleApplication.Models
{
    public class Employees : IEmployees
    {

        public IEnumerable<Employee> All()
        {
            var e = new List<Employee>();

            e.Add(new Employee
            {
                Id = 1,
                DateEmployed = DateTime.Now.AddYears(-10),
                FullName = "Employee #1",
                JobTitle = "CEO",
                ManagerId = null,
                Salary = 1000000
            });

            e.Add(new Employee
            {
                Id = 2,
                DateEmployed = DateTime.Now.AddYears(-9),
                FullName = "Employee #2",
                JobTitle = "PA",
                ManagerId = 1,
                Salary = 1000
            });

            return e;
        }

    }
}
