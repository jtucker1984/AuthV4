using Microsoft.EntityFrameworkCore;

namespace AuthV4.Models.Domain
{
    [PrimaryKey(nameof(Id))]
    public class Vendor
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string VenName { get; set; }

        public string? Description { get; set; }

        public string? VenImageUrl { get; set; }

        public string? StreetAddress { get; set; }

        public string? State { get; set; }

        public string? Zip { get; set; }

        public string? HoursOfService { get; set; }

        public string ItemId = Guid.NewGuid().ToString();
        public Item ItemsClass { get; set; }
    }
}
