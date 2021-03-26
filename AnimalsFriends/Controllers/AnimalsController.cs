using AnimalsFriends.Helpers;
using AnimalsFriends.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult AddAnimal([FromBody] Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();

            return CreatedAtAction("GetAnimal", new { id = animal.Id}, animal);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnimal([FromRoute] int id, [FromBody] Animal animal)
        {
            if (id != animal.Id)
            {
                return BadRequest();
            }

            try
            {
                _context.Entry(animal).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Animals.Find(id) == null)
                {
                    return NotFound();
                }

                throw;
            }           

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveAnimal([FromRoute] int id)
        {
            var animal = _context.Animals.Find(id);

            if (animal == null)
            {
                return NotFound();
            }

            _context.Animals.Remove(animal);
            _context.SaveChanges();

            return (IActionResult)animal;
        }
    }
}
