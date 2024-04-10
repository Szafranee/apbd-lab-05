namespace Lab_05_API;

public class Visit(int id, DateTime date, int animalId, string description, decimal cost)
{
    public int Id { get; set; } = id;
    public DateTime Date { get; set; } = date;
    public int AnimalId { get; set; } = animalId;
    public string Description { get; set; } = description;
    public decimal Cost { get; set; } = cost;
}