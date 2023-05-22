using Newtonsoft.Json;
using WebApplicationEmployees.Models;

namespace WebApplicationEmployees.DataAccess
{
    public class EmployeeApiClient : IEmployeeApiClient
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        public EmployeeApiClient(IConfiguration config)
        {
            httpClient = new HttpClient();
            this.configuration = config;
            var apiClient = this.configuration.GetSection("HttpApiClient").Get<HttpApiClient>();
            httpClient.BaseAddress = new Uri(apiClient.BaseAddress);
        }

        public async Task<string> GetEmployeeById(int id)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"employee/{id}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync(); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public async Task<string> GetEmployees()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("employees");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync(); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
