using CleanTodo.Domain.Exceptions;
using CleanTodo.Domain.Interfaces.Repositories;

namespace CleanTodo.Application.UseCase
{
    public class DeleteShipUseCase
    {
        private readonly IShipRepository _repo;

        public DeleteShipUseCase(IShipRepository repo) => _repo = repo;

        public async Task Execute(Guid id)
        {
            var existing = await _repo.FindById(id);
            if (existing == null) throw new NotFoundException(id);

            await _repo.Delete(id);
        }
    }
}