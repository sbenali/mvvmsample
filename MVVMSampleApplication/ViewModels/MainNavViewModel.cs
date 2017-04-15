using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MVVMSampleApplication.ViewModels
{
    public class MainNavViewModel: BindableBase
    {
        private IRegionManager _regionManager;


        #region commands


        private DelegateCommand _addEmployeeCommand;
        public DelegateCommand AddEmployeeCommand => _addEmployeeCommand == null ? new DelegateCommand(ExecAddEmployee, CanExecAddEmployee) : _addEmployeeCommand;

        private bool CanExecAddEmployee()
        {
            return true;
        }
        private void ExecAddEmployee()
        {
            _regionManager.RequestNavigate("MainRegion", new Uri("AddEmployeeView", UriKind.Relative));

        }

        private DelegateCommand _listEmployeesCommand;
        public DelegateCommand ListEmployeesCommand =>
            _listEmployeesCommand == null ? new DelegateCommand(ExecListEmployees, CanExecListEmployees) : _listEmployeesCommand;

        private bool CanExecListEmployees()
        {
            return true;
        }

        private void ExecListEmployees()
        {
            _regionManager.RequestNavigate("MainRegion", new Uri("EmployeeListView", UriKind.Relative));
        }

        #endregion

        #region properties
        private string _title = "Navigation Area - NO MENU AVAILABLE";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ObservableCollection<MenuItem> _navItems;
        public ObservableCollection<MenuItem> NavItems
        {
            get { return _navItems; }
            set { SetProperty(ref _navItems, value); }
        }
        #endregion



        public MainNavViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(Views.EmployeeListView));
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(Views.AddEmployeeView));

            NavItems = new ObservableCollection<MenuItem>();

            //it would be possible to read menu structure from some storage
            var mnuListEmployees = new MenuItem {
                Uid="mnuListEmployees",
                Header = "List Employees",
                Command = ListEmployeesCommand
            };
            mnuListEmployees.SetResourceReference(FrameworkElement.StyleProperty, "DefaultMenuItemStyle");
            NavItems.Add(mnuListEmployees);


            var mnuAddEmployee = new MenuItem
            {
                Uid="mnuAddEmployee",
                Header = "Add Employee",
                Command = AddEmployeeCommand
            };
            
            NavItems.Add(mnuAddEmployee);

        }

    }

    public class NavItem: BindableBase
    {
        private string _caption;
        public string Caption
        {
            get { return _caption; }
            set { SetProperty(ref _caption, value); }
        }


    }

}
