using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proposal.Core.Utils
{
    public static class QueryBuilderExtensions
    {
        public static string ApplyPaging(this string query, QueryBuilderSearchModel model)
        {
            //if (!string.IsNullOrWhiteSpace(model.OrderBy))
            //    query += $" order by {model.OrderBy}";

            //if (model.Skip != null || model.Take != null)
            //{
            //    if (string.IsNullOrWhiteSpace(model.OrderBy))
            //        throw new Exception("OrderBy must be defined when using Skip/Take");

            //    if (model.Skip != null)
            //        query += $" offset {model.Skip.GetValueOrDefault()} rows";
            //    if (model.Take != null)
            //        query += $" fetch next {model.Take.GetValueOrDefault()} rows only";
            //}

            if (model.Pager != null && !model.Pager.Ignore)
            {
                if (!string.IsNullOrWhiteSpace(model.Pager.OrderBy))
                    query += $" order by {model.Pager.OrderBy}";

                if (model.Pager.Skip != null || model.Pager.Take != null)
                {
                    query += $" order by {(string.IsNullOrWhiteSpace(model.Pager.OrderBy) ? "1" : model.Pager.OrderBy)}";
                    query += $" offset {model.Pager.Skip.GetValueOrDefault()} rows";

                    if (model.Pager.Take != null)
                        query += $" fetch next {model.Pager.Take.GetValueOrDefault()} rows only";
                }
            }

            return query;
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, QueryBuilderSearchModel model)
        {
            if (model.Pager != null && !model.Pager.Ignore)
            {
                if (!string.IsNullOrWhiteSpace(model.Pager.OrderBy))
                {
                    bool descending = false;
                    string[] token = model.Pager.OrderBy.Split(' ');
                    string column = token[0].Trim();
                    if (token.Length > 1)
                        descending = token[1].ToUpper() == "DESC";

                    query = query.OrderBy(column, descending);
                }

                if (model.Pager.Skip != null)
                    query = query.Skip(model.Pager.Skip.Value);

                if (model.Pager.Take != null)
                    query = query.Take(model.Pager.Take.Value);

            }

            return query;
        }

        private static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderByProperty, bool desc)
        {
            orderByProperty = orderByProperty.ToPascalCase();

            string command = desc ? "OrderByDescending" : "OrderBy";
            var type = typeof(TEntity);
            var property = type.GetProperty(orderByProperty);
            if (property == null)
                throw new Exception($"{orderByProperty} property not found in type {type.FullName}");

            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                                            source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<TEntity>(resultExpression);
        }
    }

    public class QueryBuilderSearchModel
    {
        //public int? Skip { get; set; }
        //public int? Take { get; set; }        
        //public string OrderBy { get; set; }

        public PagerModel Pager { get; set; } = new PagerModel();
    }

    public class PagerModel
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public string OrderBy { get; set; }
        public bool Ignore { get; set; }
    }

}
