using LINE.SMA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINE.SMA.Repositories.BaseRepository
{
    public static class DbExtends
    {
        public static TEntity Insert<TEntity>(this DbSet<TEntity> source, TEntity entity) where TEntity : class
        {
            AutoSetEntity(entity);

            return source.Add(entity);
        }

        public static IEnumerable<TEntity> InsertRange<TEntity>(this DbSet<TEntity> source, IEnumerable<TEntity> entities) where TEntity : class
        {
            if (entities == null || entities.Count() == 0)
                return entities;
            foreach (var entity in entities)
            {
                AutoSetEntity(entity);
            }
            return source.AddRange(entities);
        }

        public static object AutoSetEntity(object entity)
        {
            if (entity.GetType().GetProperty("Id") != null && entity.GetType().GetProperty("Id").GetValue(entity, null).AsLong() == 0)
            {
                var id = Snowflake.GenerateId();
                entity.GetType().GetProperty("Id").SetValue(entity, id, null);
            }
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (!property.CanWrite)
                    continue;
                if (property.PropertyType == typeof(string) && property.GetValue(entity, null) == null)
                {
                    property.SetValue(entity, "", null);
                }
                else if (property.PropertyType == typeof(int?) && property.GetValue(entity, null) == null)
                {
                    property.SetValue(entity, 0, null);
                }
                else if (property.PropertyType == typeof(decimal?) && property.GetValue(entity, null) == null)
                {
                    property.SetValue(entity, 0.00M, null);
                }
            }
            return entity;
        }
    }
}
