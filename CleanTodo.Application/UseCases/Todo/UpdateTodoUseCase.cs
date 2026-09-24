using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Exceptions;
using CleanTodo.Domain.Interfaces.Repositories;

namespace CleanTodo.Application.UseCase
{
    public class UpdateTodoUseCase
    {
        private readonly ITodoRepository _repo;

        public UpdateTodoUseCase(ITodoRepository repo) => _repo = repo;

        public async Task Execute(Guid id, TodoUpdateDto dto)
        {
            var existing = await _repo.FindById(id);
            if (existing == null) throw new NotFoundException(id);

            // Map DTO to entity (Title -> Text)
            existing.Text = dto.Title ?? existing.Text;
            existing.IsCompleted = dto.IsCompleted;

            await _repo.Update(existing);
        }
    }
}