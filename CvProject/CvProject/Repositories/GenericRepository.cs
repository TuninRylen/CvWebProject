using CvProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CvProject.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        DbCvEntities db = new DbCvEntities();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public void Add(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public void Delete(T entity) 
        {
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }

        public T Get(T entity) 
        {
            return db.Set<T>().Find(entity); 
        }

        public void Update(T entity) 
        {
            db.SaveChanges();
        }

    }


}