using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernate_Relationships.Models.NHibernate
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                  .ConnectionString(@"Data Source=(local)\sqlexpress;Initial Catalog=Relacionamentos;Integrated Security=True")
                              .ShowSql()
                )
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Carro>())
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Pessoa>())
               .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
               .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}