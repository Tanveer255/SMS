using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models.DTO
{
    public class SearchCourseDTO : SearchDTO<CourseDTO, Enums.CompanyColumns>
    {
        public Guid CourseID { get; set; }
    }
}
