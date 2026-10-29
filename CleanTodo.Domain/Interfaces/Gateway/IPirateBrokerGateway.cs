using System;
using System.Collections.Generic;
using System.Text;
using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Entities;

namespace CleanTodo.Domain.Interfaces.Gateway
{
    public interface IPirateBrokerGateway
    {
        Task<List<string>> GetAllPorts();

        Task Sail(BrokerShipDto ship, string destination);
    }
}
