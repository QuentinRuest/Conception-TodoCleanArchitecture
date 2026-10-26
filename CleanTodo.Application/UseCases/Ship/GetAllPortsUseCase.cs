using CleanTodo.Domain.Interfaces.Gateway;

namespace CleanTodo.Application.UseCase
{
    public class GetAllPortsUseCase
    {
        private readonly IPirateBrokerGateway _gateway;

        public GetAllPortsUseCase(IPirateBrokerGateway gateway)
        {
            _gateway = gateway;
        }

        public Task<List<string>> Execute()
        {
            return _gateway.GetAllPorts();
        }
    }
}