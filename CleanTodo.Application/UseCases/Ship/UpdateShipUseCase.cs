using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Exceptions;
using CleanTodo.Domain.Interfaces.Repositories;

namespace CleanTodo.Application.UseCase
{
    public class UpdateShipUseCase
    {
        private readonly IShipRepository _repo;

        public UpdateShipUseCase(IShipRepository repo) => _repo = repo;

        public async Task Execute(Guid id, ShipUpdateDto dto)
        {
            Ship existing = await _repo.FindById(id);
            if (existing == null) throw new NotFoundException(id);
            
            existing.name = dto.name;
            existing.goldCargo = dto.goldCargo;
            existing.captain = dto.captain;
            existing.status = dto.status;
            existing.crewSize = dto.crewSize;

            await _repo.Update(existing);
        }
    }
}