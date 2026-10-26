namespace CleanTodo.Domain.DTOS;

public class ShipUpdateDto
{
    public string name { get; set; }
    public int goldCargo { get; set; }
    public string captain { get; set; }
    public string status { get; set; }
    public int crewSize { get; set; }

    public DateTime lastModified { get; set; } = DateTime.Now;
}