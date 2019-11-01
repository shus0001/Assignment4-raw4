namespace _2._Data_Layer_Abstraction
{
    public class PagingAttributes
    {
        public const int MaxPageSize = 10;
        private int _pageSize = MaxPageSize;
        public int Page { get; set; } = 0;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = System.Math.Min(value, MaxPageSize);
        }
    }
}