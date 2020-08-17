using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Common.Models
{
    public class SortModel
    {
        public bool ReturnSorted { get; set; } = true;

        public string SortBy { get; set; } = "Name";
    }
}
