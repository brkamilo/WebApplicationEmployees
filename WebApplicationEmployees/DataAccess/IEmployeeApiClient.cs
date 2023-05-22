using WebApplicationEmployees.Models;

namespace WebApplicationEmployees.DataAccess
{
    public interface IEmployeeApiClient
    {
        Task<string> GetEmployees();
        Task<string> GetEmployeeById(int id);

    }
}
