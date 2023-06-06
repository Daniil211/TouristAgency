using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Application.MobileClient.Models
{
    public class User
    {
        [JsonPropertyName("user")]
        public int Id { get; set; }

        [JsonPropertyName("nameuser")]
        public string UserName { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }
        [JsonPropertyName("prem")]
        public bool IsPremiumMember { get; set; }
        [JsonPropertyName("role")]
        public string Role { get; set; }
        [JsonPropertyName("datecreate")]
        public DateTime DateCreated { get; set; }
        [JsonPropertyName("fio")]
        public string Fio { get; set; }
        [JsonPropertyName("datebirth")]
        public DateTime DateOfBirth { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
    }
}
