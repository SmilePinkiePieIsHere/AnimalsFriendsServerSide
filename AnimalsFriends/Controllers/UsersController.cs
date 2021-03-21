using AnimalsFriends.Helpers;
using AnimalsFriends.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

        [HttpGet]
        public IActionResult GetAll([FromQuery] QueryParameters queryParameters)
        {
            IQueryable<User> users = _context.Users;

            users = users
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return Ok(users.ToArray());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
