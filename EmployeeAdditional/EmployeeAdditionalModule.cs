using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAdditional
{
    public class EmployeeAdditionalModule : IModule
    {
        private IRegionManager _regionManager;

        public void Initialize()
        {
            
            Console.WriteLine("Module Initialized");
        }


        public EmployeeAdditionalModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(Views.AdditionalView));
        }


    }
}
