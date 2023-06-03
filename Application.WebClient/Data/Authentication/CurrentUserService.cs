using Application.Persistence.Models;
using Microsoft.AspNetCore.Authentication;

namespace GameIndustry_v2.Data.Authentication;

/// <summary>
/// Interface ICurrentUserService
/// </summary>
public interface ICurrentUserService
{
    /// <summary>
    /// Gets or sets the authorized user.
    /// </summary>
    /// <value>The authorized user.</value>
    public User? AuthorizedUser { get; set; }
}

/// <summary>
/// Class CurrentUserService.
/// Implements the <see cref="GameIndustry_v2.Data.Authentication.ICurrentUserService" />
/// </summary>
/// <seealso cref="GameIndustry_v2.Data.Authentication.ICurrentUserService" />
public class CurrentUserService : ICurrentUserService
{
    /// <summary>
    /// Gets or sets the authorized user.
    /// </summary>
    /// <value>The authorized user.</value>
    public User? AuthorizedUser { get; set; }
}