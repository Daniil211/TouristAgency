using Application.Authorize.Utils;
using Application.WebApi.Services;
using Application.WebApi.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Application.WebApi.Controllers
{
    [Route("[controller]")]
    [EnableCors("CorsPolicy")]
    public class MyProtectedController : Controller
    {
        private readonly IUsersService _usersService;

        public MyProtectedController(IUsersService usersService)
        {
            _usersService = usersService;
            _usersService.CheckArgumentIsNull(nameof(usersService));
        }

        [Authorize(Policy = PolicyTypes.RequireAdmin)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAdmin()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userDataClaim = claimsIdentity.FindFirst(ClaimTypes.UserData);
            var userId = userDataClaim.Value;

            return Ok(new
            {
                Id = 1,
                Title = "Hello from My Protected Admin Api Controller! [Authorize(Policy = CustomRoles.Admin)]",
                Username = this.User.Identity.Name,
                UserData = userId,
                TokenSerialNumber = await _usersService.GetSerialNumberAsync(int.Parse(userId)),
                Roles = claimsIdentity.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList()
            });
        }
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult GetAuthorize()
        {
            return Ok(new
            {
                Id = 1,
                Title = "Hello from My Protected Controller! [Authorize]",
                Username = this.User.Identity.Name
            });
        }
    }
}
