using LINE.SMA.Infrastructure;
using LINE.SMA.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LINE.SMA.Repositories.Context
{
    public class KtDbContext : DbContext
    {
        private static string connectStr = String.Empty;

        public KtDbContext()
            : base(GetConnectionString())
        {
            Database.SetInitializer<KtDbContext>(null);
        }

        private static string GetConnectionString()
        {
            try
            {
                try
                {
                    if (ConfigurationManager.ConnectionStrings.Count > 1)
                    {
                        connectStr = ConfigurationManager.ConnectionStrings["DataBaseConnString_TEST"].ConnectionString;
                    }
                }
                catch {; }
                
                return connectStr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除自动建表时自动加上s的复数形式
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //移除一对多的级联删除约定
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //多对多启用级联删除约定
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<SysMenu>().ToTable("sys_menu");

            Assembly ass = Assembly.Load("LINE.SMA.Model");
            List<Type> types = new List<Type>();
            types.AddRange(ass.GetTypes().Where(t => t.IsClass && !t.IsInterface && !t.IsAbstract && t.GetInterface("EntityBase") != null));
            foreach (var item in types)
            {
                MethodInfo method = modelBuilder.GetType().GetMethod("Entity");
                method = method.MakeGenericMethod(new Type[] { item });
                method.Invoke(modelBuilder, null);
            }
            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<t_user> t_user { get; set; }  

        //public DbSet<t_role> t_role { get; set; }

    }
}
