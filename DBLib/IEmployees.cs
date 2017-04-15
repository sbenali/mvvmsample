using System.Collections.Generic;

namespace DBLib
{
    public interface IEmployees
    {
        IEnumerable<Employee> All();
    }
}