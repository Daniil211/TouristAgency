using Microsoft.AspNetCore.Authorization;

namespace GameIndustry_v2.Data.Authentication;

public class AdultRequirement : IAuthorizationRequirement
{
    public static string ClaimName => "Age";
}