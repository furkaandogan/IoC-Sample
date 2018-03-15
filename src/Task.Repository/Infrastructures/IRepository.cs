using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;

namespace Task.Repository.Infrastructures
{
    public interface IRepository<T>
        where T : Models.Tables.Base
    {
        IQueryable<T> List();
        T GetById(int id);
        void Add(T model);
        void DeleteById(int id);
        void Delete(T model);
        void Edit(T model);
        void Save();
    }

    
}