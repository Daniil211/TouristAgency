﻿namespace Application.Web.Client.Models
{
    public class RegistrationResponseDTO
    {
        public bool IsRegistrationSuccessful { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
