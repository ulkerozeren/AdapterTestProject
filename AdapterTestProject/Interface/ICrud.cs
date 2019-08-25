using System.Linq;

namespace AdapterTestProject.Interface
{
    public interface ICrud
    {
        T Insert<T>(T model) where T : class;
        T Update<T>(T model) where T : class;
        void Delete<T>(int id) where T : class;
        T Find<T>(int id) where T : class;
        IQueryable<T> Get<T>() where T : class;
    }
}