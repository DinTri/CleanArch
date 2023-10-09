using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TrifonCleanArch.Application.Commands;
using TrifonCleanArch.Application.Handlers;
using TrifonCleanArch.Application.Queries;
using TrifonCleanArch.Application.Services.Abstract;
using TrifonCleanArch.Application.Services.Concrete;
using TrifonCleanArch.Domain;
using TrifonCleanArch.Utils;

namespace TrifonCleanArch;

internal class Program
{
    protected Program()
    {
    }

    static async Task Main(string[] args)
    {
        var serviceProvider = ConfigureServices();

        var mediator = serviceProvider.GetRequiredService<IMediator>();
        var inputOutput = serviceProvider.GetRequiredService<InputOutput>();

        decimal grossValue = inputOutput.GetGrossValue();

        var query = new CalculateNetSalaryQuery(grossValue);
        var salary = await mediator.Send(query);

        inputOutput.DisplayNetSalary(salary);

        Console.ReadLine();
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Application
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        // Services
        services.AddScoped<ISalaryCalculatorService, SalaryCalculatorService>();
        services.AddTransient<InputOutput>();
        services.AddTransient<IRequestHandler<CalculateNetSalaryQuery, Salary>, CalculateNetSalaryQueryHandler>();
        services.AddTransient<IRequestHandler<CalculateNetSalaryCommand, Salary>, CalculateNetSalaryCommandHandler>();
        services.AddTransient<ISalaryCalculatorService, SalaryCalculatorService>();
        return services.BuildServiceProvider();
    }
}