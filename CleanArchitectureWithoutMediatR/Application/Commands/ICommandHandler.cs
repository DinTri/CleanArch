namespace CleanArchitectureWithoutMediatR.Application.Commands
{
    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }
}
