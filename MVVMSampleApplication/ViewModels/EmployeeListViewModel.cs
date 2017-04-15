using MVVMSampleApplication.Models;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSampleApplication.ViewModels
{
    public class EmployeeListViewModel:BindableBase, INavigationAware
    {
        private IEmployees _employees;
        public EmployeeListViewModel(IEmployees employees)
        {
            _employees = employees;

            EmployeesList = new ObservableCollection<Employee>(_employees.All());      
        }

        private ObservableCollection<Employee> _employeesList;
        public ObservableCollection<Employee> EmployeesList
        {
            get { return _employeesList; }
            set { SetProperty(ref _employeesList, value); }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //check if we have a new employee in params
            if (navigationContext.Parameters["employee"] != null)
            {
                Employee e = (Employee)navigationContext.Parameters["employee"];
                EmployeesList.Add(e);
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //do nothing
        }
    }
}
