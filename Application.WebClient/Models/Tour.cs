namespace Application.WebClient.Models
{
    public class Tour
    {
        public int TourId { get; set; }

        public string TourName { get; set; } = null!;

        public string Duration { get; set; } = null!;

        public decimal Price { get; set; }

        public byte[]? Image { get; set; }

        public string? Description { get; set; }

    }
}
