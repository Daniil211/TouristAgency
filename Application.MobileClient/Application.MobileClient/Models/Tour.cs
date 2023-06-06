using System;
using System.Text.Json.Serialization;

namespace Application.MobileClient.Models
{
    public class Tour
    {
        [JsonPropertyName("id")]
        public int TourId { get; set; }

        [JsonPropertyName("name")]
        public string TourName { get; set; }

        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("video")]
        public string VideoTour { get; set; }
        [JsonPropertyName("sale")]
        public bool InSale { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
        [JsonPropertyName("time")]
        public DateTime? Time { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
