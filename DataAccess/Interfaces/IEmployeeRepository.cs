using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IEmployeeRepository
    {
        void SaveEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployee(long id);
        void DeleteEmployee(long id);
        void UpdateEmployee(Employee employee);
    }
}
