using MediatR;
using TrifonCleanArch.Application.Queries;
using TrifonCleanArch.Application.Services.Abstract;
using TrifonCleanArch.Domain;

namespace TrifonCleanArch.Application.Handlers
{
    public class CalculateNetSalaryQueryHandler : IRequestHandler<CalculateNetSalaryQuery, Salary>
    {
        private readonly ISalaryCalculatorService _salaryCalculatorService;

        public CalculateNetSalaryQueryHandler(ISalaryCalculatorService salaryCalculatorService)
        {
            _salaryCalculatorService = salaryCalculatorService;
        }

        public Task<Salary> Handle(CalculateNetSalaryQuery request, CancellationToken cancellationToken)
        {
            var salary = _salaryCalculatorService.CalculateNetSalary(request.GrossValue);
            return Task.FromResult(salary);
        }
    }
}
