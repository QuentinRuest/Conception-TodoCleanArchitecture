using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Interfaces.Gateway;
using CleanTodo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Application.UseCase;

public class SailShipUseCase
{
    private readonly IShipRepository _shipRepository;
    private readonly IPirateBrokerGateway _pirateBrokerGateway;

    public SailShipUseCase(IShipRepository shipRepository, IPirateBrokerGateway pirateBrokerGateway)
    {
        _shipRepository = shipRepository;
        _pirateBrokerGateway = pirateBrokerGateway;
    }
    public async Task Execute(Guid id, string destination)
    {
        var ship = await _shipRepository.FindById(id);

        var ports = await _pirateBrokerGateway.GetAllPorts();

        if (!ports.Contains(destination))
        {
            throw new InvalidOperationException(
                "Le port de destination n'existe pas."
            );
        }

        await _pirateBrokerGateway.Sail(ship, destination);
    }
}
