namespace MyMind.Web.Database
{
    public interface ISessionFactory
    {
        ISession Create();
    }
}
