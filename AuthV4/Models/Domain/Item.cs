using Microsoft.EntityFrameworkCore;

namespace AuthV4.Models.Domain
{
    [PrimaryKey(nameof(Id))]
    public class Item
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string? Name { get; set; }

        public string Weight { get; set; }
        public long Price { get; set; } = 0;
        public string Description { get; set; }

        public string Type { get; set; }
        public string ItemUrl { get; set; }


        
    }
}
