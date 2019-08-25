using System.Linq;
using AdapterTestProject.Interface;

namespace AdapterTestProject.Adapter
{
    public class DatabaseAdapter : ICrud
    {
        public void Delete<T>(int id) where T : class
        {
            T model = Find<T>(id);

            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                databaseContext.Set<T>().Remove(model);
                databaseContext.SaveChanges();
            }
        }

        public T Find<T>(int id) where T : class
        {
            T entity;

            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                entity = databaseContext.Set<T>().Find(id);
            }

            return entity;
        }

        public IQueryable<T> Get<T>() where T : class
        {
            DatabaseContext databaseContext = new DatabaseContext();

            return databaseContext.Set<T>();
        }

        public T Insert<T>(T model) where T : class
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                databaseContext.Set<T>().Add(model);
                databaseContext.SaveChanges();
            }

            return model;
        }

        public T Update<T>(T model) where T : class
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                databaseContext.Set<T>().Update(model);
                databaseContext.SaveChanges();
            }

            return model;
        }
    }
}