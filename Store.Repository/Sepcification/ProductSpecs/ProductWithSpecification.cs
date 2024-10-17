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
        public ProductWithSpecification(ProductSpecification specs) :
            base(Prod => (!specs.BrandId.HasValue || Prod.BrandId == specs.BrandId.Value) &&
                         (!specs.TypeId.HasValue || Prod.TypeId == specs.TypeId.Value))
        {
            AddIncludes(x => x.Brand);
            AddIncludes(x => x.Type);
            
        }
    }
}
