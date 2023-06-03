using Microsoft.AspNetCore.Authorization;

namespace Application.WebClient.Data.Authentication;

public class OverAgeRequirement: IAuthorizationRequirement
{
    public static string ClaimName => "Age";
}