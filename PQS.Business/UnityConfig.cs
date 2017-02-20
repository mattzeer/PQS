using System;
using Microsoft.Practices.Unity;
using PQS.Business.Admin;
using PQS.Business.Admin.Impl;
using PQS.Business.Quote;
using PQS.Business.Quote.Impl;
using PQS.Dal.SqlServer.Manager;
using Dds.Join2Ship.Dal.SqlServer.Manager;

namespace PQS.Business
{ 
    public class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IManagerData, ManagerData>(new TransientLifetimeManager());
            container.RegisterType<IUserService, UserService>(new TransientLifetimeManager());
            container.RegisterType<IQuoteService, QuoteService>(new TransientLifetimeManager());
            container.RegisterType<IFileService, FileService>(new TransientLifetimeManager());
        }

        public static T Resolve<T>()
        {
            return container.Value.Resolve<T>();
        }
    }
}
