using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace MVVMSampleApplication.Models
{

    public class Employee: BindableBase
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set { SetProperty(ref _fullName,value); }
        }

        private string _title;    
        public string JobTitle
        {
            get { return _title; }
            set { SetProperty(ref _title,value); }
        }

        private int? _managerId;
        public int? ManagerId
        {
            get { return _managerId; }
            set { SetProperty(ref _managerId,value); }
        }


        private DateTime _dateEmployed;

        public DateTime DateEmployed
        {
            get { return _dateEmployed; }
            set { SetProperty(ref _dateEmployed,value); }
        }

        private float _salary;

        public float Salary
        {
            get { return _salary; }
            set { SetProperty(ref _salary, value); }
        }


    }

}