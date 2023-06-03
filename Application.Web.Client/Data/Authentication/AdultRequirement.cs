using Microsoft.AspNetCore.Authorization;

namespace Application.Web.Client.Data.Authentication;

public class AdultRequirement : IAuthorizationRequirement
{
    public static string ClaimName => "Age";
}