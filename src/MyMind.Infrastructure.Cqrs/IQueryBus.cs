using System.Threading.Tasks;

namespace MyMind.Infrastructure.Cqrs
{
    public interface IQueryBus
    {
        W Execute<W>(IQuery<W> query) where W : IQueryResult;
    }

}