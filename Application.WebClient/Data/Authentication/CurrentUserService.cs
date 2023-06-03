using Application.Database;
using Application.Database.Models;
//using Microsoft.AspNetCore.Authentication;

namespace Application.WebClient.Data.Authentication;

public interface ICurrentUserService
{
    public User? AuthorizedUser { get; set; }
}

public class CurrentUserService : ICurrentUserService
{
    public User? AuthorizedUser { get; set; }
}