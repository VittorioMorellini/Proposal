using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Microsoft.Data.SqlClient;
//using Z.EntityFramework.Extensions;

namespace Proposal.Core.Utils
{
    public static class DbContextUtils
    {
        [Obsolete]
        public static void AddOrUpdate<TEntity, TKey>(this DbContext context, TKey id, TEntity entity)
            where TEntity : class
        {
            var i = context.Set<TEntity>().Find(id);
            if (i != null)
            {
                context.Entry(i).State = EntityState.Detached;

                context.Set<TEntity>().Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                context.Set<TEntity>().Add(entity);
                var e = context.Entry(entity);
            }
        }

        [Obsolete]
        public static TEntity Save<TEntity, TKey>(this DbContext context, TKey id, TEntity entity)
            where TEntity : class
        {
            context.AddOrUpdate(id, entity);
            context.SaveChanges();
            return entity;
        }

        public static void Save<TEntity>(this DbContext context, TEntity entity) where TEntity : class
        {
            context.BulkMerge(new TEntity[] { entity });
        }

        public static void Save<TEntity>(this DbContext context, IEnumerable<TEntity> entities, bool includeGraph = false) where TEntity : class
        {
            context.BulkMerge(entities, options => options.IncludeGraph = includeGraph);
        }

        [Obsolete]
        public static async Task<TEntity> SaveAsync<TEntity, TKey>(this DbContext context, TKey id, TEntity entity)
            where TEntity : class
        {
            context.AddOrUpdate(id, entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public static EntityState GetEntityState<TEntity, TKey>(this DbContext context, TKey id, TEntity entity)
            where TEntity : class
        {
            return context.Set<TEntity>().Find(id) != null ? EntityState.Modified : EntityState.Added;
        }

        public static bool Delete<TEntity, TKey>(this DbContext context, TKey id)
            where TEntity : class
        {
            bool status = false;

            var i = context.Set<TEntity>().Find(id);
            if (i != null)
            {
                context.Entry(i).State = EntityState.Deleted;
                context.SaveChanges();

                status = true;
            }

            return status;
        }
    }
}
