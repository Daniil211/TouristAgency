using Microsoft.AspNetCore.Authorization;

namespace GameIndustry_v2.Data.Authentication;

public class OverAgeRequirement: IAuthorizationRequirement
{
    public static string ClaimName => "Age";
}