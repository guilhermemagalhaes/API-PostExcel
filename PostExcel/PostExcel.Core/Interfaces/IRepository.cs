using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PostExcel.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity CreateOrUpdate(TEntity entity);
        Task<IList<TEntity>> CreateOrUpdate(IList<TEntity> entity);
        TEntity Get(int id);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null);
        void Delete(int id);
    }
}
