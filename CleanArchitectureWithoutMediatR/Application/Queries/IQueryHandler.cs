namespace CleanArchitectureWithoutMediatR.Application.Queries
{
    public interface IQueryHandler<in TQuery, out TResult>
    {
        TResult Handle(TQuery query);
    }
}
