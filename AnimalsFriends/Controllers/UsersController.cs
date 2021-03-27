using AnimalsFriends.Helpers;
using AnimalsFriends.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalsFriends.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AnimalsFriendsContext _context;
        public UsersController(AnimalsFriendsContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public async Task<OWinResponseToken> Register(User user)
        {
            return await _userService.Register(user);
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<OWinResponseToken> Login(User user)
        {
            return await _userService.Login(user);
        }

        [AllowAnonymous]
        [Route("refresh_token")]
        [HttpPost]
        public async Task<OWinResponseToken> Refresh([FromBody] string refreshToken)
        {
            return await _userService.Refresh(refreshToken);
        }

        [Route("msg")]
        [HttpPost]
        public string GetUserMsg()
        {
            return " is authenticated";
        }
    }
}
