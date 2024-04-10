namespace Lab_05_API;

public interface IShelterDb
{
    public ICollection<Animal> GetAll();
    public Animal? GetById(int id);
    public void Add(Animal animal);
    public void Update(int id, Animal animal);
    public void Delete(int id);

}