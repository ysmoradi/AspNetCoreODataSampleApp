using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
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

            var customers1 = await httpClient.GetStringAsync("api/customers");
            var customers2 = await httpClient.GetStringAsync("api/customers?$filter=Gender eq 'Woman'");
            var customers3 = await httpClient.GetStringAsync("api/customers?$filter=Gender eq 'Woman'&$orderby=Address/StreetNo");
            var customers4 = await httpClient.GetStringAsync("api/customers?$filter=contains(FirstName,'Ali')");

            var batchResponse = await httpClient.PostAsync("api/$batch", new StringContent(@"
{
    ""requests"": [
        {
            ""id"": ""1"",
            ""method"": ""GET"",
            ""url"": ""https://localhost:5001/api/customers?$filter=Gender eq 'Woman'""
        },
        {
            ""id"": ""2"",
            ""method"": ""GET"",
            ""url"": ""https://localhost:5001/api/customers?$filter=contains(FirstName,'Ali')""
        }
    ]
}"
                , Encoding.UTF8, "application/json"));

            var batchResponseString = await batchResponse.Content.ReadAsStringAsync();
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
