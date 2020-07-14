using AspNetCoreODataSampleApp.Dto;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspNetCoreODataSampleApp.Controllers
{
    [ApiController, Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        [HttpGet, EnableQuery]
        public IEnumerable<CustomerDto> Get()
        {
            return new[]
            {
                new CustomerDto
                {
                    Id = 1,
                    FirstName = "Reza",
                    LastName = "Hamedani",
                    Gender = Gender.Man,
                    Address = new AddressInfoDto
                    {
                        PostalCode = "12345", StreetNo = 12
                    }
                },new CustomerDto
                {
                    Id = 2,
                    FirstName = "Ali",
                    LastName = "Akbari",
                    Gender = Gender.Man,
                    Address = new AddressInfoDto
                    {
                        PostalCode = "13245", StreetNo = 11
                    }
                },new CustomerDto
                {
                    Id = 3,
                    FirstName = "Zohre",
                    LastName = "Farahani",
                    Gender = Gender.Woman,
                    Address = new AddressInfoDto
                    {
                        PostalCode = "12354", StreetNo = 10
                    }
                },new CustomerDto
                {
                    Id = 4,
                    FirstName = "Shiva",
                    LastName = "Abdoli",
                    Gender = Gender.Woman,
                    Address = new AddressInfoDto
                    {
                        PostalCode = "54123", StreetNo = 9
                    }
                },new CustomerDto
                {
                    Id = 5,
                    FirstName = "Keyvan",
                    LastName = "Akbari",
                    Gender = Gender.Man,
                    Address = new AddressInfoDto
                    {
                        PostalCode = "54321", StreetNo = 8
                    }
                }
            };
        }
    }
}
