namespace AuthV4.Models.Dto
{
    public class ItemDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string? Name { get; set; }

        public string Weight { get; set; }
        public long Price { get; set; } = 0;
        public string Description { get; set; }

        public string Type { get; set; }
        public string ItemImageUrl { get; set; }
    }
}
