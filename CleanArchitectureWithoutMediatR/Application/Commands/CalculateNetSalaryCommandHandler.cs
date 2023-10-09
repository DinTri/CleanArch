using CleanArchitectureWithoutMediatR.Application.Queries;
using CleanArchitectureWithoutMediatR.Domain;

namespace CleanArchitectureWithoutMediatR.Application.Commands
{
    public class CalculateNetSalaryCommandHandler : ICommandHandler<CalculateNetSalaryCommand>
    {
        private readonly IQueryHandler<CalculateNetSalaryQuery, SalaryCalculation> _queryHandler;

        public CalculateNetSalaryCommandHandler(IQueryHandler<CalculateNetSalaryQuery, SalaryCalculation> queryHandler)
        {
            this._queryHandler = queryHandler;
        }

        public void Handle(CalculateNetSalaryCommand command)
        {
            var query = new CalculateNetSalaryQuery
            {
                EmployeeName = command.EmployeeName,
                GrossSalary = command.GrossSalary
            };

            var result = _queryHandler.Handle(query);
        }
    }
}
