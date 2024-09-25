namespace AuthV4.Models.Dto
{
    public class UpdateVendorDto
    {
       

        public string? VenName { get; set; }

        public string Description { get; set; }

        public string VenImageUrl { get; set; }

        public string StreetAddress { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string HoursOfService { get; set; }
    }
}
