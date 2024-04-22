using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    private IAnimalService _animalService;

    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpGet]
    public IActionResult GetAnimals([FromQuery] string orderBy = "Name")
    {
        try
        {
            var animals = _animalService.GetAnimals(orderBy);
            return Ok(animals);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        var affectedCount = _animalService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        try
        {
            var affectedCount = _animalService.UpdateAnimal(id, animal);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAniaml(int id)
    {
        try
        {
            var affectedCount = _animalService.DeleteAnimal(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    
}