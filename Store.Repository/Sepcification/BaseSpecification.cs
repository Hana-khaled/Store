﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Sepcification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        protected void AddIncludes(Expression<Func<T, object>> includeEx)
            => Includes.Add(includeEx);

        protected void AddOrderBy(Expression<Func<T, object>> orderByEx)
            => OrderBy = orderByEx;
        protected void AddOrderByDescending(Expression<Func<T, object>> orderBydescEx)
            => OrderByDescending = orderBydescEx;
    }
}
