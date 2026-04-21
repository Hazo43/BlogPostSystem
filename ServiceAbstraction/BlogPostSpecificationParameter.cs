using Domain.Entites.Enums;
using Shared.Enums;


namespace ServiceAbstraction
{
    //1 => error عشان كان مطلع  ServiceAbstraction في ال BlogPostSpecificationParameter دا  class حطيت ال

    //2=> two enum بسبب اني كنت عامل BlogPostWithCategoryAndStatus كان في ال errorال

    // domain مكانو في ال Status بتاع ال enum لي ؟ عشان ال reference from domain انا خدت
    public class BlogPostSpecificationParameter
    {
        public int? CategoryId { get; set; }
        public BlogPostSort? Sort { get; set; }
        public Status? Status { get; set; }

        // Skip -> pageIndex

        private int _pageIndex { get; set; } = 1;
        public int pageIndex
        {
            get
            {
                return _pageIndex;
            }
            set
            {
                _pageIndex = (value <= 0) ? 1 : value;
            }
        }

        // Take -> PageSize

        private const int defaultPageSize = 5;
        private const int maxPageSize = 10;

        private int _pageSize = defaultPageSize;

        public int pageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                if (value <= 0)
                    _pageSize = defaultPageSize;
                else if (value > maxPageSize)
                    _pageSize = maxPageSize;
                else
                    _pageSize = value;
            }
        }

    }
}
