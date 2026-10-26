using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Domain.Interfaces.Gateway
{
    public interface IPirateBrokerGateway
    {
        Task<List<string>> GetAllPorts();
    }
}
