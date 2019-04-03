using System.Collections.Generic;
using System.Linq;

namespace Brotal
{
    public static class PagedListExtensions
    {
        public static IPagedList<T> GetPagedList<T>(this IEnumerable<T> source,
            int                                                         index, int size)
        {
            var res = new PagedList<T>
            {
                PageIndex   = index,
                PageSize    = size,
                ResultCount = source.Count()
            };
            res.AddRange(source.Skip((index - 1) * size).Take(size));

            return res;
        }


    }
}