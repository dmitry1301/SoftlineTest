using DataAccess.Data;
using DataAccess.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ApplicationDbContext context;
        private DbSet<Employee> employeeEntity;
        public EmployeeRepository(ApplicationDbContext context)
        {
            this.context = context;
            employeeEntity = context.Set<Employee>();
        }


        public void SaveEmployee(Employee employee)
        {
            context.Entry(employee).State = EntityState.Added;
            context.SaveChanges();
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return employeeEntity.AsEnumerable();
        }

        public Employee GetEmployee(long id)
        {
            return employeeEntity.SingleOrDefault(s => s.Id == id);
        }
        public void DeleteEmployee(long id)
        {
            Employee student = GetEmployee(id);
            employeeEntity.Remove(student);
            context.SaveChanges();
        }
        public void UpdateEmployee(Employee employee)
        {
            context.SaveChanges();
        }

    }
}
