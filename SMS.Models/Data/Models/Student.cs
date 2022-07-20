using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models.Data.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid     ID                   { get; set; }
        public string?  LastName             { get; set; }
        public string?  FirstMidName         { get; set; }
        public DateTime EnrollmentDate       { get; set; }
        public int      CNICBform            { get; set; }
        public string?  FatherName           { get; set; }
        public string?  FatherOccupation     { get; set; }
        public string?  Gender               { get; set; }
        public string?  Islam                { get; set; }
        public string?  BloodGroup           { get; set; }
        public int      MobileNo             { get; set; }
        public string?  EmailAddress         { get; set; }
        public string?  Provice              { get; set; }
        public string?  PermanentAddress     { get; set; }
        public string?  PostalAddress        { get; set; }
        public byte[]?  Photo                { get; set; }
        public int      FatherCNIC           { get; set; }
        public int      FamilyMonthlyIncome  { get; set; }
        public DateTime DateOfBirth          { get; set; }
        public bool?    HafizEQuran          { get; set; }
        public bool?    MaritalStatus        { get; set; }
        public int      GuardianContactNo    { get; set; }
        public string?  Nationality          { get; set; }
        public string?  DomicileDistrict     { get; set; }
        public DateTime CreateDate           { get; set; }
        public DateTime UpdateDate           { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
