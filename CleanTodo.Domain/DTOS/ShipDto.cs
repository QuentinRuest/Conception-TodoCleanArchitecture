using CleanTodo.Domain.Entities;

namespace CleanTodo.Domain.DTOS;

public class ShipDto
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

    public ShipDto() { }


    // Devrait être fait dans Mapping -> automapper.
    public ShipDto(Ship ship)
    {
        Id = ship.Id;
        name = ship.name;
        goldCargo = ship.goldCargo;
        createdAt = ship.createdAt;
        captain = ship.captain;
        status = ship.status;
        crewSize = ship.crewSize;
        createdBy = ship.createdBy;
        lastModified = ship.lastModified;
    }
}
