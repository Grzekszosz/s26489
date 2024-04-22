using WebApplication1.Model;

namespace WebApplication1.Services;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    int CreateAnimal(Animal animal);
    int UpdateAnimal(int IDAnimal, Animal animal);
    bool AvaliableAnimal(int IDAnimal);
    int DeleteAnimal(int IDAnimal);
}