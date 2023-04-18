using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using mamographyBackend.Context;
using System.Linq;
using mamographyBackend.Context.user;
using mamographyBackend.Infrastructure;
using mamographyBackend.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using mamographyBackend.Models;

namespace mamographyBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
       
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;
        private readonly IJwtAuthManager _jwtAuthManager;

        public AccountController(ILogger<AccountController> logger, IUserService userService, IJwtAuthManager jwtAuthManager)
        {
            _logger = logger;
            _userService = userService;
            _jwtAuthManager = jwtAuthManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //var x = StringCipher.Encrypt(request.Password, "protek");
            //var y = StringCipher.Encrypt(x, "protek");
            var dc = new ApplicationDbContext();
            var sorgu =  (from sss in dc.RPAC_UserLogins where sss.UserName == request.UserName && sss.Password ==request.Password   select sss.Id).Count();
           
            if (sorgu>0)
            {
                var role = (from Ul in dc.RPAC_UserLogins join UR in dc.RPAC_UserRoles on Ul.UserRoleId equals UR.Id where Ul.UserName == request.UserName && Ul.Password == request.Password select UR.Name).FirstOrDefault();
               // var role = _userService.GetUserRole(request.UserName);
                var claims = new[]
                {
                new Claim(ClaimTypes.Name,request.UserName),
                new Claim(ClaimTypes.Role, role)
            };

                var jwtResult = _jwtAuthManager.GenerateTokens(request.UserName, claims, DateTime.Now);
                _logger.LogInformation($"User [{request.UserName}] logged in the system.");
                return Ok(new LoginResult
                {
                    UserName = request.UserName,
                    Role = role,
                    AccessToken = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString
                });
            }
            else
            {
                return Unauthorized();
            }
           

          
        }

        [HttpGet("user")]
        [Authorize]
        public ActionResult GetCurrentUser()
        {
            return Ok(new LoginResult
            {
                UserName = User.Identity?.Name,
                Role = User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty,
                OriginalUserName = User.FindFirst("OriginalUserName")?.Value
            });
        }

        [HttpPost("logout")]
        [Authorize]
        public ActionResult Logout()
        {
            // optionally "revoke" JWT token on the server side --> add the current token to a block-list
            // https://github.com/auth0/node-jsonwebtoken/issues/375

            var userName = User.Identity?.Name;
            _jwtAuthManager.RemoveRefreshTokenByUserName(userName);
            _logger.LogInformation($"User [{userName}] logged out the system.");
            return Ok();
        }

        [HttpPost("refresh-token")]
        [Authorize]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                var userName = User.Identity?.Name;
                _logger.LogInformation($"User [{userName}] is trying to refresh JWT token.");

                if (string.IsNullOrWhiteSpace(request.RefreshToken))
                {
                    return Unauthorized();
                }

                var accessToken = await HttpContext.GetTokenAsync("Bearer", "access_token");
                var jwtResult = _jwtAuthManager.Refresh(request.RefreshToken, accessToken, DateTime.Now);
                _logger.LogInformation($"User [{userName}] has refreshed JWT token.");
                return Ok(new LoginResult
                {
                    UserName = userName,
                    Role = User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty,
                    AccessToken = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString
                });
            }
            catch (SecurityTokenException e)
            {
                return Unauthorized(e.Message); // return 401 so that the client side can redirect the user to login page
            }
        }

        [HttpPost("impersonation")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult Impersonate([FromBody] ImpersonationRequest request)
        {
            var userName = User.Identity?.Name;
            _logger.LogInformation($"User [{userName}] is trying to impersonate [{request.UserName}].");
            var dc = new ApplicationDbContext();
            var impersonatedRole = (from Ul in dc.RPAC_UserLogins join UR in dc.RPAC_UserRoles on Ul.UserRoleId equals UR.Id where Ul.UserName == request.UserName select UR.Name).FirstOrDefault();
            //var impersonatedRole = _userService.GetUserRole(request.UserName);
            if (string.IsNullOrWhiteSpace(impersonatedRole))
            {
                _logger.LogInformation($"User [{userName}] failed to impersonate [{request.UserName}] due to the target user not found.");
                return BadRequest($"The target user [{request.UserName}] is not found.");
            }
            if (impersonatedRole == UserRoles.Admin)
            {
                _logger.LogInformation($"User [{userName}] is not allowed to impersonate another Admin.");
                return BadRequest("This action is not supported.");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.UserName),
                new Claim(ClaimTypes.Role, impersonatedRole),
                new Claim("OriginalUserName", userName ?? string.Empty)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(request.UserName, claims, DateTime.Now);
            _logger.LogInformation($"User [{request.UserName}] is impersonating [{request.UserName}] in the system.");
            return Ok(new LoginResult
            {
                UserName = request.UserName,
                Role = impersonatedRole,
                OriginalUserName = userName,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }

        [HttpPost("stop-impersonation")]
        public ActionResult StopImpersonation()
        {
            var userName = User.Identity?.Name;
            var originalUserName = User.FindFirst("OriginalUserName")?.Value;
            if (string.IsNullOrWhiteSpace(originalUserName))
            {
                return BadRequest("You are not impersonating anyone.");
            }
            _logger.LogInformation($"User [{originalUserName}] is trying to stop impersonate [{userName}].");
            var dc = new ApplicationDbContext();
            var role = (from Ul in dc.RPAC_UserLogins join UR in dc.RPAC_UserRoles on Ul.UserRoleId equals UR.Id where Ul.UserName == originalUserName select UR.Name).FirstOrDefault();
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,originalUserName),
                new Claim(ClaimTypes.Role, role)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(originalUserName, claims, DateTime.Now);
            _logger.LogInformation($"User [{originalUserName}] has stopped impersonation.");
            return Ok(new LoginResult
            {
                UserName = originalUserName,
                Role = role,
                OriginalUserName = null,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }

        [HttpPost("HastaneRole")]
        public  ActionResult HastaneRole([FromBody] Sorgula username)
        {
            var dc = new ApplicationDbContext();
            var list = (from Ul in dc.RPAC_UserLogins
                        join UR in dc.RPAC_UserHospitalPeople on Ul.Id equals UR.UserLoginId
                        
                        where Ul.UserName == username.username   select new { Ul.Id,Ul.UserName, UR.HospitalId }).ToList();
            var role = (from s in list
                        join UU in dc.RPAC_Hospitals on s.HospitalId equals UU.Id
                        select UU.CompanyName).FirstOrDefault();
            return Ok(new LoginResult
            {
                UserName = "",
                Role = role,
                OriginalUserName = "",
                AccessToken = "",
                RefreshToken = ""
            });
        }
    }

    public class LoginRequest
    {
        [Required]
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }

    public class LoginResult
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("originalUserName")]
        public string OriginalUserName { get; set; }

        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }

    public class RefreshTokenRequest
    {
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }

    public class ImpersonationRequest
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }
    }
}
