using Application.Commands.Contracts;

namespace Application.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }

    public interface IHandlerGet
    {
        Task<ICommandResult> Handle(Guid id);
    }

    public interface IHandlerDelete
    {
        Task<ICommandResult> HandleDelete(Guid id);
    }

    public interface IHandlerList
    {
        Task<ICommandResult> Handle();
    }
}
