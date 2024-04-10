namespace Lab_05_API;

public class Visit(int id, DateTime date, Animal animal, string description, decimal cost)
{
    public int Id { get; set; } = id;
    public DateTime Date { get; set; } = date;
    public Animal Animal { get; set; } = animal;
    public string Description { get; set; } = description;
    public decimal Cost { get; set; } = cost;
}