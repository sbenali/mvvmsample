using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBLib
{

    public class Employee
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string JobTitle { get; set; }
        public int? ManagerId { get; set; }
        public DateTime DateEmployed { get; set; }
        public float Salary { get; set; }
    }

}