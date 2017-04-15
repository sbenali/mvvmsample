using System.Collections.Generic;

namespace MVVMSampleApplication.Models
{
    public interface IEmployees
    {
        IEnumerable<Employee> All();
    }
}