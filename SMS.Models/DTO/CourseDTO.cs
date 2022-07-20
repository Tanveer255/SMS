using SMS.Models.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models.DTO
{
    public  class CourseDTO
    {
        [Required]
        public Guid CourseID { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public int? Credits { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreateTimeStamp { get; set; }
       

        [DataType(DataType.DateTime)]
        public DateTime UpdateTimeStamp { get; set; }
        public Course MapDtoToModel(CourseDTO dto)
        {
            return new Course {
                CourseID    = dto.CourseID,
                Title       = dto.Title,
                Credits     = dto.Credits,
                CreateTimeStamp  = dto.CreateTimeStamp,
                UpdateTimeStamp = dto.UpdateTimeStamp
            };
        }
    }
}
