using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Sepcification.ProductSpecs
{
    public class ProductSpecification
    {
        // Includes
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }

        // Ordering
        public string? Sort { get; set; }

        // Pagination
        public int PageIndex { get; set; }

        public const int MAX_PAGE_SIZE = 50;

        private int _pageSize;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > MAX_PAGE_SIZE) ? int.MaxValue : value; }
        }

        // Searching
        private string? _search;

        public string? Search
        {
            get => _search;
            set => _search = value?.Trim().ToLower();
        }

    }
}
