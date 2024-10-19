using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Sepcification
{
    public interface ISpecification<T>
    {
        // Criteria
        Expression<Func<T, bool>> Criteria { get; } // for where conditions

        // Includes List for having different types of includes (Brands - Types)
        List<Expression<Func<T, object>>> Includes { get; }
        
        // Ordering
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }

        // Pagination
        int Skip { get; }
        int Take { get; }
        bool IsPaginated { get; }

    }
}
