using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Repository.Infrastructures
{
    public abstract class BaseRepository<T, Context> : IRepository<T>
          where T : Models.Tables.Base, new()
          where Context : DbContext, new()
    {

        protected Context DbContext { get; set; }
        protected IDbSet<T> DbSet { get; set; }

        public BaseRepository()
        {
            DbContext = new Context();
            DbSet = DbContext.Set<T>();
        }
        public virtual void Add(T model)
        {
            DbSet.Add(model);
        }

        public void DeleteById(int id)
        {
            Models.Tables.Base model = new T();
            model.Id = id;
            DbSet.Remove((T)model);
        }
        public virtual void Delete(T model)
        {
            DbSet.Remove(model);
        }

        public virtual void Edit(T model)
        {
            DbContext.Entry<T>(model).State = EntityState.Modified;
        }

        public T GetById(int id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<T> List()
        {
            return DbSet;
        }

        public virtual void Save()
        {
            DbContext.SaveChanges();
        }
    }
}
