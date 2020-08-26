using System.Linq;

namespace Project.Common.Models
{
    public class PageRepositoryModel<T> where T : class
    {
        public IQueryable<T> QueryResult { get; set; }

        public int CurrentPageIndex { get; set; } = 1;
        public int TotalPageCount { get; set; }
        public int CurrentPageSize { get; set; } = 5;
        public int CurrentRowCount { get; set; }

        public bool ReturnPaged { get; set; } = true;
    }
}
