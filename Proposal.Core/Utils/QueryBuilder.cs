﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proposal.Core.Utils
{
    public static class QueryBuilderExtensions
    {

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
