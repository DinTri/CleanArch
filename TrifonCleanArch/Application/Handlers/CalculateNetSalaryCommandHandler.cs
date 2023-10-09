using MediatR;
using TrifonCleanArch.Application.Commands;
using TrifonCleanArch.Application.Services.Abstract;
using TrifonCleanArch.Domain;

namespace TrifonCleanArch.Application.Handlers
{
    public class CalculateNetSalaryCommandHandler : IRequestHandler<CalculateNetSalaryCommand, Salary>
    {
        private readonly ISalaryCalculatorService _salaryCalculatorService;

        public CalculateNetSalaryCommandHandler(ISalaryCalculatorService salaryCalculatorService)
        {
            _salaryCalculatorService = salaryCalculatorService;
        }

        public Task<Salary> Handle(CalculateNetSalaryCommand request, CancellationToken cancellationToken)
        {
            var salary = _salaryCalculatorService.CalculateNetSalary(request.GrossValue);
            return Task.FromResult(salary);
        }
    }
}
