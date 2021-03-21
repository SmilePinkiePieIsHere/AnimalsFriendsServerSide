using AnimalsFriends.Helpers;
using AnimalsFriends.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        public IActionResult GetAll([FromQuery] AnimalQueryParameters queryParameters)
        {
            IQueryable<Animal> animals = _context.Animals;
            
            if (queryParameters.Status != null)
            {
                animals = animals.Where(a => a.CurrentStatus.ToString().ToLower() == queryParameters.Status.ToLower());
            }

            if (queryParameters.Species != null)
            {
                animals = animals.Where(a => a.Species.ToString().ToLower() == queryParameters.Species.ToLower());
            }

            animals = animals
               .Skip(queryParameters.Size * (queryParameters.Page - 1))
               .Take(queryParameters.Size);

            return Ok(animals.ToArray());
        }

        [HttpGet("{id}")]
        public IActionResult GetAnimal(int id)
        {
            var animal = _context.Animals.Find(id);
            if(animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }

        [HttpPost]
        public IActionResult UpdateAnimal()
        {
            var animals = _context.Animals.ToList();
            return Ok(animals);
        }
    }
}
