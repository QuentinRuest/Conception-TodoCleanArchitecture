using CleanTodo.Application.Services;
using CleanTodo.Application.UseCase;
using CleanTodo.Application.UseCases;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanTodo.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Validators
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Todo UseCases
        services.AddScoped<CreateTodoUseCase>();
        services.AddScoped<DeleteTodoUseCase>();
        services.AddScoped<GetTodoUseCase>();
        services.AddScoped<GetAllTodosUseCase>();
        services.AddScoped<UpdateTodoUseCase>();
        //services.AddScoped<ToggleTodoCompleteStatusUseCase>();

        // Auth UseCases
        services.AddScoped<LoginUseCase>();
        services.AddScoped<RegisterUseCase>();

        services.AddScoped<JwtService>();

        return services;
    }
}