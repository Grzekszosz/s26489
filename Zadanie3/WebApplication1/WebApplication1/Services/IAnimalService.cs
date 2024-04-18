using WebApplication1.Model;

namespace WebApplication1.Services;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimals();
    
}