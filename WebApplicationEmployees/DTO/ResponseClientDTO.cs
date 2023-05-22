using WebApplicationEmployees.Models;

namespace WebApplicationEmployees.DTO
{
    public class ResponseClientDTO
    {
        public string? status { get; set; }
        public Employee? data { get; set; }
        public string? message { get; set; }
    }
}
