using BlazorServer.Models;
using BlazorShared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly CrudBlazorContext _dbContext;
        public EmployeeController(CrudBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetList()
        {
            var response = new Response<List<EmployeeDTO>>();
            var list = new List<EmployeeDTO>();

            try
            {
                foreach (var item in await _dbContext.Employees.Include(d => d.Department).ToListAsync())
                {
                    list.Add(new EmployeeDTO
                    { 
                        IdEmployee = item.IdEmployee,
                        Name = item.Name,
                        IdDepartment = item.IdDepartment,
                        Salary = item.Salary,
                        ContractDate = item.ContractDate,
                        Department = new DepartmentDTO
                        {
                            IdDepartment = item.Department.IdDepartment,
                            Name = item.Department.Name
                        }
                    });
                }

                response.IsSuccess = true;
                response.Value = list;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(list);
        }

        [HttpGet]
        [Route("Search/{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var response = new Response<EmployeeDTO>();
            var employeeDTO = new EmployeeDTO();

            try
            {
                var employeeDB = await _dbContext.Employees.FirstOrDefaultAsync(e => e.IdEmployee == id);

                if (employeeDB != null)
                {
                    employeeDTO.IdEmployee = employeeDB.IdEmployee;
                    employeeDTO.Name = employeeDB.Name;
                    employeeDTO.Salary = employeeDB.Salary;
                    employeeDTO.ContractDate = employeeDB.ContractDate;
                    employeeDTO.IdDepartment = employeeDB.IdDepartment;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "ID not found";
                }

                response.IsSuccess = true;
                response.Value = employeeDTO;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateEmployee(EmployeeDTO employee)
        {
            var response = new Response<int>();

            try
            {
                var employeeDB = new Employee
                {
                    Name = employee.Name,
                    IdDepartment = employee.IdDepartment,
                    Salary = employee.Salary,
                    ContractDate = employee.ContractDate
                };

                _dbContext.Employees.Add(employeeDB);
                await _dbContext.SaveChangesAsync();

                if(employeeDB.IdEmployee != 0)
                {
                    response.IsSuccess = true;
                    response.Value = employeeDB.IdEmployee;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Error, try again.";
                }    

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDTO employee, int id)
        {
            var response = new Response<int>();

            try
            {
                var employeeDB = await _dbContext.Employees.FirstOrDefaultAsync(e => e.IdEmployee == id);
               
                if (employeeDB != null)
                {
                    employeeDB.Name = employee.Name;
                    employeeDB.IdDepartment = employee.IdDepartment;
                    employeeDB.Salary = employee.Salary;
                    employeeDB.ContractDate = employee.ContractDate;

                    _dbContext.Employees.Update(employeeDB);
                    await _dbContext.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Value = employeeDB.IdEmployee;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Error, employee not found";
                } 
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var response = new Response<int>();

            try
            {
                var employeeDB = await _dbContext.Employees.FirstOrDefaultAsync(e => e.IdEmployee == id);

                if (employeeDB != null)
                {
                    _dbContext.Employees.Remove(employeeDB);
                    await _dbContext.SaveChangesAsync();

                    response.IsSuccess = true;
                    //response.Value = employeeDB.IdEmployee;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Error, employee not found";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
    }
}
