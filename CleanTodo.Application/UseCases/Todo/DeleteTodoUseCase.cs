using CleanTodo.Domain.Exceptions;
using CleanTodo.Domain.Interfaces.Repositories;

namespace CleanTodo.Application.UseCase
{
    public class DeleteTodoUseCase
    {
        private readonly ITodoRepository _repo;

        public DeleteTodoUseCase(ITodoRepository repo) => _repo = repo;

        public async Task Execute(Guid id)
        {
            var existing = await _repo.FindById(id);
            if (existing == null) throw new NotFoundException(id);

            await _repo.Delete(id);
        }
    }
}