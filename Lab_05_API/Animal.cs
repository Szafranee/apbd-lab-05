namespace Lab_05_API;

public class Animal(int id, string name, string type, double weight, string color)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Type { get; set; } = type;
    public double Weight { get; set; } = weight;
    public string Color { get; set; } = color;
    private ICollection<Visit> _vetVisits = new List<Visit>();

    public void AddVetVisit(Visit visit)
    {
        _vetVisits.Add(visit);
    }

    public ICollection<Visit> GetVetVisits()
    {
        return _vetVisits;
    }
}