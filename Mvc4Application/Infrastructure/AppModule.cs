namespace Mvc4Application.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using DataAccess.Repository;
    using Ninject.Modules;

    public sealed class AppModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUser>().To<UserRepository>();
        }
    }
}