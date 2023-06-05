using System;
using System.Text.Json.Serialization;

namespace Application.MobileClient.Models
{
    public class Tour
    {
        [JsonPropertyName("tourid")]
        public int TourId { get; set; }

        [JsonPropertyName("tourname")]
        public string TourName { get; set; }

        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("videotour")]
        public string VideoTour { get; set; }
        [JsonPropertyName("insale")]
        public bool InSale { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
        [JsonPropertyName("time")]
        public DateTime? Time { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
