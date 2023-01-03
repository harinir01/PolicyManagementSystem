namespace Policy_Management_System_API
{
    using System.ComponentModel.DataAnnotations.Schema;
    [NotMapped]
    public class SearchParams
    {
        public string InsuredName { get; set; } = String.Empty;
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public int Premium { get; set; } = 0;
        public int PolicyTypeId { get; set; } = 0;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SortType { get; set; } = String.Empty;
        public string SortBy { get; set; } = String.Empty;

        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 200;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}