using CleanTodo.Application.UseCase;
using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Interfaces.Gateway;
using CleanTodo.Domain.Interfaces.Repositories;
using Moq;
using NUnit.Framework;
using System.Net.Http;

namespace TodoApplicationTests;

public class ShipTests
{
    private Mock<IShipRepository> _repository = null!;
    private Mock<IPirateBrokerGateway> _gateway = null!;
    private SailShipUseCase _useCase = null!;
    private Ship _ship = null!;

    [SetUp]
    public void Setup()
    {
        _repository = new Mock<IShipRepository>();
        _gateway = new Mock<IPirateBrokerGateway>();

        _useCase = new SailShipUseCase(
            _repository.Object,
            _gateway.Object
        );

        _ship = new Ship
        {
            Id = Guid.NewGuid(),
            name = "Going Merry",
            captain = "Luffy",
            goldCargo = 100,
            crewSize = 10,
            createdBy = "utilisateur-test",
            createdAt = DateTime.UtcNow,
            lastModified = DateTime.UtcNow,
            status = "docked"
        };

        _repository.Setup(repo => repo.FindById(_ship.Id)).ReturnsAsync(_ship);

        _repository.Setup(repo => repo.Delete(_ship.Id)).Returns(Task.CompletedTask);

        _gateway.Setup(gateway => gateway.GetAllPorts()).ReturnsAsync(new List<string> { "prof" });
    }

    [Test]
    public async Task SailSuccess_ShouldSendThenDeleteShip()
    {
        _gateway.Setup(gateway => gateway.Sail(
                It.IsAny<BrokerShipDto>(),
                "prof"
            ))
            .Returns(Task.CompletedTask);

        await _useCase.Execute(_ship.Id, "prof");

        _gateway.Verify(
            gateway => gateway.Sail(
                It.IsAny<BrokerShipDto>(),
                "prof"
            ),
            Times.Once
        );

        _repository.Verify(
            repo => repo.Delete(_ship.Id),
            Times.Once
        );
    }
}