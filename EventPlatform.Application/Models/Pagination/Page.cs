namespace EventPlatform.Application.Models.Pagination
{
    public class Page<T>
    {
        public int PageIndex { get; }
        public IEnumerable<T> Items { get; }
        public int Count { get; }
        public int Total { get; }

        public Page(IEnumerable<T> items, int pageIndex, int totalItems, int itemsCount)
        {
            Items = items;
            PageIndex = pageIndex;
            Total = totalItems;
            Count = itemsCount;
        }
    }
}
