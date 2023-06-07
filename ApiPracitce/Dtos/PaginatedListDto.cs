namespace ApiPracitce.Dtos
{
    public class PaginatedListDto<T>
    {
        public PaginatedListDto(List<T> items, int pageIndex, int pageSize, int totalCount)
        {
            this.Items = items;
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalPage = (int)Math.Ceiling(totalCount / (double)pageSize);
        }


        public List<T> Items { get; set; }
        public bool HasNext => PageIndex < TotalPage;
        public bool HasPreview => PageIndex > 1;
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
    }
}
