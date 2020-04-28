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
    public class LineDbContext : DbContext
    {
        private static string connectStr = String.Empty;

        public LineDbContext()
            : base("LineDbContext")
        {
            Database.SetInitializer<LineDbContext>(new CreateDatabaseIfNotExists<LineDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除自动建表时自动加上s的复数形式
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //移除一对多的级联删除约定
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //多对多启用级联删除约定
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<Function>().ToTable("t_function");

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

        public DbSet<Function> t_function { get; set; }  

        //public DbSet<t_role> t_role { get; set; }

    }
}
