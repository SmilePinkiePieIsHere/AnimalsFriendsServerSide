using AnimalsFriends.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalsFriends.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly AnimalsFriendsContext _context;
        public AnimalsController(AnimalsFriendsContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IEnumerable<Animal> GetAll()
        {
            return _context.Animals.ToList();
        }
    }
}
