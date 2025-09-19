using Microsoft.AspNetCore.Mvc;
using BlazorServer.Models;
using BlazorShared;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        //inyeccion de servicio de DB, en criollo el enlace que nos va a permitir darle instrucciones y leer la data que contiene
        private readonly CrudBlazorContext _dbContext;
        public DepartmentController(CrudBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetList()
        {
            //List<DepartmentDTO> list = new List<DepartmentDTO>();
            var list = new List<DepartmentDTO>();
            var response = new Response<List<DepartmentDTO>>();

            try
            {
                foreach (var item in await _dbContext.Departments.ToListAsync())
                {
                    list.Add(new DepartmentDTO
                    {
                        IdDepartment = item.IdDepartment,
                        Name = item.Name
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
            return Ok(response.Value);
        }
    }
}
  