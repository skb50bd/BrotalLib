using System;
using System.Collections.Generic;

namespace Brotal
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int ResultCount { get; set; }

        public PaginationModel EmitPagination =>
            new PaginationModel
            {
                PageIndex = PageIndex,
                PageSize = PageSize,
                ResultCount = ResultCount,
                CurrentCount = Count
            };
        public IPagedList<TDestination> CastList<TDestination>(Func<T, TDestination> convert)
        {
            var res = new PagedList<TDestination>
            {
                PageIndex = PageIndex,
                PageSize = PageSize,
                ResultCount = ResultCount
            };

            ForEach(i => res.Add(convert(i)));
            return res;
        }
    }
}
