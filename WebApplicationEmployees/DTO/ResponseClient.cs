using WebApplicationEmployees.Models;

namespace WebApplicationEmployees.DTO
{
    public class ResponseClient
    {
        public string ?status { get; set; }
        public List<Employee>? data { get; set; }
        public string? message { get; set; }
    }
}
