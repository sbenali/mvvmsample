using MVVMSampleApplication.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Subjects;

namespace MVVMSampleApplication.ViewModels
{
    public class AddEmployeeViewModel: BindableBase, INavigationAware
    {
        private IRegionManager _regionManager;
        public AddEmployeeViewModel(IRegionManager regionManager)
        {
            Employee = new Employee() { Id = 0 };

            Employee.PropertyChanged += Employee_PropertyChanged;
            _regionManager = regionManager;            
        }

        private void Employee_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SaveEmployeeCommand.RaiseCanExecuteChanged();
        }

        private DelegateCommand _saveEmployeeCommand;
        public DelegateCommand SaveEmployeeCommand => 
            _saveEmployeeCommand == null ? _saveEmployeeCommand=new DelegateCommand(ExecSaveEmployee, CanExecSaveEmployee) : _saveEmployeeCommand;

        private bool CanExecSaveEmployee()
        {
            return Employee?.Id > 0 && !string.IsNullOrEmpty(Employee?.FullName);
        }

        private void ExecSaveEmployee()
        {
            NavigationParameters param = new NavigationParameters();
            param.Add("employee", Employee);
            _regionManager.RequestNavigate("MainRegion", new Uri("EmployeeListView", UriKind.Relative), param);
        
            Employee = new Employee();             
        }

        private Employee _employee;        
        public Employee Employee
        {
            get { return _employee; }
            set { SetProperty(ref _employee, value); }
        }

        #region INavigationAware
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

            navigationContext.Parameters.Add("employee", Employee);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do nothing
        } 
        #endregion
    }
}
