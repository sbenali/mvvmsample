using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMSampleApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var b = new Bootstrapper();
            b.Run();

            //ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            //{
            //    var viewName = viewType.FullName;
            //    var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            //    viewAssemblyName += ".ViewModels";
            //    var viewModelName = String.Format("{0}ViewModel,{1}", viewName, viewAssemblyName);
            //    return Type.GetType(viewModelName);
            //});

        }
    }
}
