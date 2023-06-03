using Microsoft.AspNetCore.Authorization;

namespace Application.Web.Client.Data.Authentication;

public class OverAgeRequirement: IAuthorizationRequirement
{
    public static string ClaimName => "Age";
}