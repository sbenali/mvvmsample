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
    public class MainWindowViewModel: BindableBase
    {

        private IRegionManager _regionManager;

        private string _title = "The Main Window";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("NavRegion", typeof(Views.MainNavView));
        }




    }
}
