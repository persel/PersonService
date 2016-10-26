using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Person.DataAccess
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter);

        void Add(TEntity item);
        void Update();
        void Delete(TEntity item); // OBS: Ska eventuellt ej gå att göra delete på de flesta entiteter.
        
    }
}
