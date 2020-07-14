namespace AspNetCoreODataSampleApp.Dto
{
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
