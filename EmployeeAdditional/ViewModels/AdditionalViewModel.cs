using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAdditional.ViewModels
{
    public class AdditionalViewModel:BindableBase
    {

        private string _title = "Additional View";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


    }
}
