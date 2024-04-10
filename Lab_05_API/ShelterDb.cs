namespace Lab_05_API;

public class ShelterDb : IShelterDb
{
    private readonly ICollection<Animal> _animals = new List<Animal>
    {
        new Animal(1, "Fluffy", "Cat", 10.5, "White"),
        new Animal(2, "Rex", "Dog", 15.5, "Brown"),
        new Animal(3, "Spike", "Dog", 20.5, "Black"),
        new Animal(4, "Whiskers", "Cat", 8.5, "Gray"),
        new Animal(5, "Buddy", "Dog", 25.5, "White"),
        new Animal(6, "Mittens", "Cat", 7.5, "Black"),
        new Animal(7, "Max", "Dog", 30.5, "Brown"),
        new Animal(8, "Snowball", "Cat", 9.5, "White"),
        new Animal(9, "Luna", "Cat", 11.5, "Black"),
        new Animal(10, "Daisy", "Dog", 18.5, "Brown")
    };

    public ICollection<Animal> GetAll()
    {
        return _animals;
    }

    public Animal? GetById(int id)
    {
        return _animals.FirstOrDefault(animal => animal.Id == id);
    }

    public void Add(Animal animal)
    {
        _animals.Add(animal);
    }

    public void Update(int id, Animal animal)
    {
        var animalToUpdate = GetById(id);
        if (animalToUpdate != null)
        {
            animalToUpdate.Name = animal.Name;
            animalToUpdate.Type = animal.Type;
            animalToUpdate.Weight = animal.Weight;
            animalToUpdate.Color = animal.Color;
        }
    }

    public void Delete(int id)
    {
        var animal = GetById(id);
        if (animal != null)
        {
            _animals.Remove(animal);
        }
    }
}