using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Newtonsoft.Json;
using WebApplicationEmployees.Business;
using WebApplicationEmployees.DataAccess;
using WebApplicationEmployees.DTO;
using WebApplicationEmployees.Models;

namespace WebApplicationEmployees.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeApiClient employeeApiClient;
        private readonly IConfiguration configuration;
        public EmployeeController(IConfiguration config)
        {
            this.configuration = config;
            employeeApiClient = new EmployeeApiClient(this.configuration);
        }
        // GET        
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                string employees = await employeeApiClient.GetEmployees();
                var response = JsonConvert.DeserializeObject<ResponseClient>(employees);
                foreach (var item in response.data)
                {
                    item.employee_annual_salary = EmployeeBusiness.GetAnnualSalary(item.employee_salary);
                }
                return Json(response.data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET: EmployeeController/Details/5
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                string employees = await employeeApiClient.GetEmployeeById(id);
                var response = JsonConvert.DeserializeObject<ResponseClientDTO>(employees);
                var employee = response.data;
                employee.employee_annual_salary = EmployeeBusiness.GetAnnualSalary(employee.employee_salary);
                return Json(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        
    }
}
