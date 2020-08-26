using System;
using System.Collections.Generic;

namespace Project.Common.Models
{
    public class PageServiceModel<T> where T : class
    {
        public IEnumerable<T> QueryResult { get; set; }

        public int CurrentPageIndex { get; set; }
        public int TotalPageCount { get; set; }
        public int CurrentPageSize { get; set; } = 5;
        public int CurrentRowCount { get; set; }

        public bool ReturnPaged { get; set; } = true;

        public int FirstRowOnPage
        {
            get { return ((CurrentPageIndex - 1) * CurrentPageSize) + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPageIndex * CurrentPageSize, CurrentRowCount); }
        }

        public bool HasPreviousPage
        {
            get
            {
                return CurrentPageIndex > 1;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return CurrentPageIndex < TotalPageCount;
            }
        }
    }
}
