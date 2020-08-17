using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Models
{
    public class FilterModel
    {
        public bool ReturnFiltered
        {
            get { return !string.IsNullOrEmpty(FilterString); }
        }

        public string FilterString { get; set; }
    }
}
