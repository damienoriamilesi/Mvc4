namespace DataAccess.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;

    /// <summary>
    /// Defines interface for common data access functionality for entity.
    /// </summary>
    /// <typeparam name="TType">Type of entity.</typeparam>
    public interface IRepository<TType>
    {
        TType Add(TType entity);

        bool Update(TType entity);

        bool Delete(TType entity);

        TType Get(Expression<Func<TType, bool>> filter);

        ICollection<TType> GetAll();
    }
}