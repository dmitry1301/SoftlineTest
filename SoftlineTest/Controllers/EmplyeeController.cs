using DataAccess.Interfaces;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftlineTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftlineTest.Controllers
{
    [ApiController]
    public class EmplyeeController : ControllerBase
    {
        private IEmployeeRepository employeeRepository;
        public EmplyeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("api/getEmployee")]
        public IEnumerable<EmployeeViewModel> GetAllEmployee()
        {
            IEnumerable<EmployeeViewModel> employees = employeeRepository.GetAllEmployee().Select(s => new EmployeeViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Position = s.Position,
                Year = s.Year,
                Characteristic = s.Characteristic,
                Decree = s.Decree
            });
            return employees;
        }


        [HttpPost]
        [Route("api/addeditEmployee")]
        public ActionResult AddEditStudent(long? id, EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Employee employee = isNew ? new Employee
                    {
                        AddedDate = DateTime.UtcNow
                    } : employeeRepository.GetEmployee(id.Value);
                    employee.Name = model.Name;
                    employee.Position = model.Position;
                    employee.Year = model.Year;
                    employee.Characteristic = model.Characteristic;
                    employee.Decree = model.Decree;
                    employee.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    employee.ModifiedDate = DateTime.Now;
                    if (isNew)
                    {
                        employeeRepository.SaveEmployee(employee);
                    }
                    else
                    {
                        employeeRepository.UpdateEmployee(employee);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();
        }
        [HttpDelete]
        [Route("api/deleteEmployee")]
        public IActionResult DeleteStudent(long id)
        {
            employeeRepository.DeleteEmployee(id);
            return Ok();
        }
    }
}
