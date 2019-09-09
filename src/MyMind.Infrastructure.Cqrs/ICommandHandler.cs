using MyMind.Infrastructure.Cqrs;
using System.Threading.Tasks;

namespace MyMind.Infrastructure.Cqrs
{
    public interface ICommandHandler
    {
    }

    public interface ICommandHandler<T> : ICommandHandler where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
