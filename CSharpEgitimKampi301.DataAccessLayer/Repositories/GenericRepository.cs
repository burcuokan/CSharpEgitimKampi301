using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpEgitimKampi301.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.DataAccessLayer.Context;
using System.Data.Entity;

namespace CSharpEgitimKampi301.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        KampContext contex = new KampContext();
        private readonly DbSet<T> _object;
        public GenericRepository()
        {
            _object = contex.Set<T>();
        }
        public void Delete(T entity)
        {
            var deletedEntity = contex.Entry(entity);
            deletedEntity.State = System.Data.Entity.EntityState.Deleted;
            contex.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _object.ToList();
        }

        public T GetById(int id)
        {
            return _object.Find(id);
        }

        public void Insert(T entity)
        {
            var addedEntity = contex.Entry(entity);
            addedEntity.State = EntityState.Added;
            contex.SaveChanges();
        }

        public void Update(T entity)
        {
            var updateEntity = contex.Entry(entity);
            updateEntity.State = EntityState.Modified;
            contex.SaveChanges();
        }
    }
}
