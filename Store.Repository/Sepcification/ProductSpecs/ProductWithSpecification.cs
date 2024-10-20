using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Sepcification.ProductSpecs
{
    public class ProductWithSpecification : BaseSpecification<Product>
    {
        // Used in GetAllWithSpecification (criteria - include - order - paginate)
        public ProductWithSpecification(ProductSpecification specs) :
            base(Prod => (!specs.BrandId.HasValue || Prod.BrandId == specs.BrandId.Value) &&
                         (!specs.TypeId.HasValue || Prod.TypeId == specs.TypeId.Value) &&
                         (string.IsNullOrEmpty(specs.Search) || Prod.Name.Trim().ToLower().Contains(specs.Search))) // Criteria
        {
            // Includes
            AddIncludes(x => x.Brand);
            AddIncludes(x => x.Type);

            // Ordering
            switch (specs.Sort)
            {
                case "PriceAsc":
                    AddOrderBy(x => x.Price);
                    break;
                case "PriceDesc":
                    AddOrderByDescending(x => x.Price);
                    break;
               default:
                    AddOrderBy(x => x.Name);
                    break;
            }

            // Pagination
            ApplyPagination(specs.PageSize * (specs.PageIndex - 1), specs.PageSize);
            
        }

        // an overload to be used in GetByIdWithSpecs() method (include only, since we are returning one item)
        public ProductWithSpecification(int? id) :
            base( prod => prod.Id == id)
        {
            AddIncludes(x => x.Brand);
            AddIncludes(x => x.Type);
        }
    }
}
