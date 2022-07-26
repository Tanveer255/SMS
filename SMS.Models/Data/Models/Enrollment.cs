﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models.Data.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public Guid EnrollmentID { get; set; }
        public Guid CourseID { get; set; }
        public Guid StudentID { get; set; }
        public Grade? Grade { get; set; }

        public Course? Course { get; set; }
        public Student? Student { get; set; }
    }
}
