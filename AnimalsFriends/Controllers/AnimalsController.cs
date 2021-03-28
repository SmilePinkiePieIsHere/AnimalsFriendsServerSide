using AnimalsFriends.Helpers;
using AnimalsFriends.Models;
using AnimalsFriends.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalsFriends.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;
        public AnimalsController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] AnimalQueryParameters queryParameters)
        {
            return Ok(_animalService.GetAll(queryParameters)); 
        }

        [HttpGet("{id}")]
        public ActionResult GetAnimal(int id)
        {
            var animal = _animalService.GetAnimal(id);
            if (animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }

        [HttpPost]
        public ActionResult<Animal> AddAnimal([FromBody] Animal animal)
        {
            _animalService.AddAnimal(animal);
            return CreatedAtAction("GetAnimal", new { id = animal.Id}, animal);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAnimal([FromRoute] int id, [FromBody] Animal animal)
        {
            if (id != animal.Id)
            {
                return BadRequest();
            }

            try
            {
                _animalService.UpdateAnimal(animal);               
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (_context.Animals.Find(id) == null)
                //{
                //    return NotFound();
                //}

                return NotFound();

                throw;
            }           

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveAnimal([FromRoute] int id)
        {
            var animal = _animalService.FindAnimal(id);

            if (animal == null)
            {
                return NotFound();
            }

            _animalService.DeleteAnimal(animal);

            return Ok(animal); //(ActionResult)animal
        }
    }
}
