using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models.DTO
{
    /// <summary>
    /// This is the SearchDTO TClass which holds all data related to SearchDTO and has some properties given below.
    /// </summary>
    /// <typeparam name="TClass">is an object of TClass.</typeparam>
    /// <typeparam name="TEnum">is an object of TEnum.</typeparam>
    public class SearchDTO<TClass, TEnum>
        where TClass : class
        where TEnum : Enum
    {
        public string? Draw { get; set; }

        public TEnum? Column { get; set; }

        public string? Order { get; set; }

        public int Start { get; set; }

        public int PageSize { get; set; }

        public string? Query { get; set; }

        public int TotalFilteredRecords { get; set; }

        public int TotalRecords { get; set; }

        public IEnumerable<TClass> Records { get; set; } = new List<TClass>();
    }
}
