// AuthenticationController.cs
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

[AllowAnonymous] // Cho phép truy cập không cần xác thực
public class AuthenticationController : Controller
{
    [Route("/authenticate")]
    public async Task<IActionResult> Authenticate([FromQuery] string user, [FromQuery] string pwd)
    {
        if (user == "admin" && pwd == "adminadmin")
        {
            var userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user),
                new Claim(ClaimTypes.Email, "admin@qltv.com"),
                new Claim(ClaimTypes.Role, "Admin") // Add role claim
            };

            var userIdentity = new ClaimsIdentity(userClaims, "Library.CookieAuth");
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync("Library.CookieAuth", userPrincipal);
        }
        return Redirect("/BookManagement");
    }

    [Route("/logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("Library.CookieAuth");
        return Redirect("/BookManagement");
    }
}
