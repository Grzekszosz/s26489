using System.Globalization;
using WebApplication1.Model;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class AnimalService : IAnimalService
{
    private readonly IAnimalRepository _animalRepository;

    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        return _animalRepository.GetAnimals(orderBy);
    }

    public int CreateAnimal(Animal animal)
    {
        return _animalRepository.CreateAnimal(animal);
    }



    public int UpdateAnimal(int IDAnimal, Animal animal)
    {
        if (!_animalRepository.AvaliableAnimal(IDAnimal))
        {
            throw new Exception("Nie znaleziono zwierzaka");
        }
        return _animalRepository.UpdateAnimal(IDAnimal, animal);
    }

    public int DeleteAnimal(int IDAnimal)
    {
        if(!_animalRepository.AvaliableAnimal(IDAnimal))
        {
            throw new Exception("Nie znaleziono zwierzaka");
        }
        return _animalRepository.DeleteAnimal(IDAnimal);
    }

    public bool AvaliableAnimal(int IDAnimal)
    {
        throw new NotImplementedException();
    }
}