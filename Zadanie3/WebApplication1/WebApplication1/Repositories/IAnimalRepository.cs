using WebApplication1.Model;

namespace WebApplication1.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals();
}