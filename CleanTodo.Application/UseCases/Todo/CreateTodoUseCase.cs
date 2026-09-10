using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Exceptions;
using CleanTodo.Domain.Interfaces.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace CleanTodo.Application.UseCase;

public class CreateTodoUseCase
{
    private readonly ITodoRepository _todoRepository;
    private readonly IValidator<CreateTodoDto> _validator;

    public CreateTodoUseCase(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<TodoDto> Execute(CreateTodoDto todoDto)
    {
        Todo todo = await _todoRepository.Add(new Todo(todoDto.Title));
        return new TodoDto(todo);
    }
}