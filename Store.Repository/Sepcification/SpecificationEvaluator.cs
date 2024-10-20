using Microsoft.EntityFrameworkCore;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Sepcification
{
    public class SpecificationEvaluator<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> InputQuery, ISpecification<TEntity>specs)
        {
            var query = InputQuery;

            // Criteria
            if(specs.Criteria is not null)
            {
               query = query.Where(specs.Criteria);
            }

            //Ordering
            if(specs.OrderBy is not null)
            {
                query = query.OrderBy(specs.OrderBy);
            }

            if (specs.OrderByDescending is not null)
            {
                query = query.OrderBy(specs.OrderByDescending);
            }

            //Includes
            query = specs.Includes.Aggregate(query, (current, include) => current.Include(include));

            //Pagination
            if (specs.IsPaginated)
            {
                query = query.Skip(specs.Skip).Take(specs.Take);
            }

            return query;
        }
    }
}
