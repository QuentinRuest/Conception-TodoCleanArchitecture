using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Exceptions;
using CleanTodo.Domain.Interfaces.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace CleanTodo.Application.UseCase;

public class CreateShipUseCase
{
    private readonly IShipRepository _shipRepository;

    public CreateShipUseCase(IShipRepository shipRepository)
    {
        _shipRepository = shipRepository;
    }

    public async Task<ShipDto> Execute(CreateShipDto shipDto)
    {
        Ship ship = await _shipRepository.Add(new Ship(shipDto.name, shipDto.goldCargo, shipDto.captain, shipDto.crewSize, shipDto.createdBy));
        return new ShipDto(ship);
    }
}