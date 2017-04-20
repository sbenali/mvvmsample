using MVVMSampleApplication.Models;
using Microsoft.Practices.Unity;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Modularity;

namespace MVVMSampleApplication
{
    public class Bootstrapper: UnityBootstrapper
    {

        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<Views.MainWindowView>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (Window)this.Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType(typeof(IEmployees), typeof(Employees),"", new ContainerControlledLifetimeManager());
        }


        protected override IModuleCatalog CreateModuleCatalog()
        {
            var catalogue =  base.CreateModuleCatalog();

            catalogue.AddModule(new ModuleInfo() {
                ModuleName = typeof(EmployeeAdditional.EmployeeAdditionalModule).Name,
                ModuleType = typeof(EmployeeAdditional.EmployeeAdditionalModule).AssemblyQualifiedName
            });

            return catalogue;
        }

    }
}
