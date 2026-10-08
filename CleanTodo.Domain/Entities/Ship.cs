namespace CleanTodo.Domain.Entities;

public class Ship
{
    public Guid Id { get; set; }
    public string name { get; set; }
    public int goldCargo { get; set; }
    public DateTime createdAt { get; set; }
    public string captain { get; set; }
    public string status { get; set; }
    public int crewSize { get; set; }
    public string createdBy { get; set; }
    public DateTime lastModified { get; set; }

    /// <summary>
    /// Constructeur qui crée mon guid, date
    /// </summary>
    /// <param name="text">Le texte du todo.</param>
    public Ship(string name, int goldCargo, string captain, string status, int crewSize, string createdBy)
    {
        Id = Guid.NewGuid();
        this.name = name;
        this.goldCargo = goldCargo;
        createdAt = DateTime.Now;
        this.captain = captain;
        this.status = status;
        this.crewSize = crewSize;
        this.createdBy = createdBy;
        lastModified = DateTime.Now;
    }

    public Ship() { }
}