using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Interfaces.Repositories;

namespace CleanTodo.Application.UseCase;

public class DockShipUseCase
{
    private readonly IShipRepository _shipRepository;

    public DockShipUseCase(IShipRepository shipRepository)
    {
        _shipRepository = shipRepository;
    }

    public async Task<ShipDto> Execute(BrokerShipDto shipDto)
    {
        var ships = await _shipRepository.GetAll();

        if (ships.Count >= 8)
        {
            throw new InvalidOperationException(
                "Le port contient déjà 8 bateaux."
            );
        }

        Ship ship = new Ship(
            shipDto.name,
            shipDto.goldCargo,
            shipDto.captain,
            "Docked",
            shipDto.crewSize,
            shipDto.createdBy,
            shipDto.createdAt,
            shipDto.lastModified
        );

        Ship savedShip = await _shipRepository.Add(ship);

        return new ShipDto(savedShip);
    }
}