namespace DataAccess.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;

    public sealed class UserRepository : GenericRepository<User, DataEntityContainer>, IUser
    {
        public override bool Update(User entity)
        {
            entity.EntityKey = new EntityKey("DataEntityContainer.Users", "Id", entity.Id);
            return base.Update(entity);
        }

        public override bool Delete(User entity)
        {
            entity.EntityKey = new EntityKey("DataEntityContainer.Users", "Id", entity.Id);
            return base.Delete(entity);
        }

        public IQueryable<User> GetBySearch(Expression<Func<User, bool>> search)
        {
            return this.Context.Users.Where(search);
        }
    }
}