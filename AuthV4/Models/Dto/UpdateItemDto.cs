namespace AuthV4.Models.Dto
{
    public class UpdateItemDto
    {
        

        public string? Name { get; set; }

        public string Weight { get; set; }
        public long Price { get; set; } = 0;
        public string Description { get; set; }

        public string Type { get; set; }
        public string ItemUrl { get; set; }
    }
}
