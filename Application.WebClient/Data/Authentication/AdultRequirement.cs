using Microsoft.AspNetCore.Authorization;

namespace Application.WebClient.Data.Authentication;

public class AdultRequirement : IAuthorizationRequirement
{
    public static string ClaimName => "Age";
}