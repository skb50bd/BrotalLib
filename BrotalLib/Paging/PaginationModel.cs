using System;

namespace Brotal
{
    public class PaginationModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int ResultCount { get; set; }
        public int CurrentCount { get; set; }
        public int PageCount => (int)Math.Ceiling((decimal)ResultCount / PageSize);
        public bool HasNextPage => PageCount > PageIndex;
        public int NextPage => PageIndex + 1;
        public bool HasPrevPage => PageIndex > 1;
        public bool HasPage(int index) => 1 <= index && index <= PageCount;
        public int PrevPage => PageIndex    == 1 ? 1 : PageIndex - 1;
    }
}