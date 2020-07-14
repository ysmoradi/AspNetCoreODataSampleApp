using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AspNetCoreODataSampleApp.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5001/")
            };

            var customers1 = await httpClient.GetFromJsonAsync<CustomerDto[]>("customers");
            var customers2 = await httpClient.GetFromJsonAsync<CustomerDto[]>("customers?$filter=Gender eq 'Woman'");
            var customers3 = await httpClient.GetFromJsonAsync<CustomerDto[]>("customers?$filter=Gender eq 'Woman'&$orderby=Address/StreetNo");
            var customers4 = await httpClient.GetFromJsonAsync<CustomerDto[]>("customers?$filter=contains(FirstName,'Ali')");
        }
    }

    public class CustomerDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public AddressInfoDto Address { get; set; }
    }

    public class AddressInfoDto
    {
        public int StreetNo { get; set; }

        public string PostalCode { get; set; }
    }

    public enum Gender
    {
        Man, Woman, Other
    }
}
