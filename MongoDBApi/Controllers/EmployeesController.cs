using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBApi.Models;
using MongoDBApi.Service;

namespace MongoDBApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }



        [HttpGet]
        public ActionResult<List<Employee>> Get() {

            return _employeeService.Get();
        }


    }
}
