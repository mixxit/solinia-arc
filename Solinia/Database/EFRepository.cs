using Solinia.Database.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Solinia.Database
{
    public class EFRepository<T, TEntity> : IRepository<T, TEntity> where T : ISavable, new() 
                                                                    where TEntity : class,ISavable, new()
    {
        private SoliniaContext dbContext = new SoliniaContext();

        public T Get(long Id)
        {
            return ConvertToDomain(dbContext.Set<TEntity>().FirstOrDefault(w => w.Id == Id));
        }

        public T First()
        {
            return ConvertToDomain(dbContext.Set<TEntity>().FirstOrDefault());
        }

        public IEnumerable<long> Ids {
            get
            {
                return dbContext.Set<TEntity>().Select(t => t.Id);
            }
        }

        private T ConvertToDomain(TEntity entity)
        {
            if (entity == null)
                return default(T);

            T returnValue = new T();
            entity.CopyPropertiesTo<TEntity, T>(returnValue);
            entity.CopyFieldsTo<TEntity, T>(returnValue);
            return returnValue;
        }

        public T Set(T savableObject)
        {
            if (savableObject == null)
                return default(T);

            var converted = ConvertToDTO(savableObject);

            if (converted == null)
                return default(T);

            var varDbObject = dbContext.Set<TEntity>().FirstOrDefault(w => w.Id == savableObject.Id);
            if (varDbObject == null)
                varDbObject = dbContext.Set<TEntity>().Add(converted);
            else
                dbContext.Entry(varDbObject).CurrentValues.SetValues(ConvertToDTO(savableObject));

            dbContext.SaveChanges();
            return ConvertToDomain(varDbObject);
        }

        private TEntity ConvertToDTO(T entity)
        {
            if (entity == null)
                return default(TEntity);

            TEntity returnValue = new TEntity();
            entity.CopyPropertiesTo<T,TEntity>(returnValue);
            entity.CopyFieldsTo<T, TEntity>(returnValue);
            return returnValue;
        }

    }
}
