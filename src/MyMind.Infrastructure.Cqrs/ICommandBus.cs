using MyMind.Infrastructure.Cqrs;
using System.Threading.Tasks;

namespace MyMind.Infrastructure.Cqrs
{
    public interface ICommandBus
    {
        Task ExecuteAsync<T>(T command) where T : ICommand;
    }
}
