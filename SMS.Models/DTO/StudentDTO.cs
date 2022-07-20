using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Models.Data.Models;

namespace SMS.Models.DTO
{
    public class StudentDTO
    {
        [Required]
        public Guid ID { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string? FirstMidName { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EnrollmentDate { get; set; }
        [Required(ErrorMessage ="Please Enter CNIC Or B-Form Number")]
        public int CNICBform { get; set; }
        [Required]
        public string? FatherName { get; set; }
        public string? FatherOccupation { get; set; }
        [Required]
        public string? Gender { get; set; }
        public string? Islam { get; set; }
        public string? BloodGroup { get; set; }
        [Required(ErrorMessage ="Please Enter contact No")]
        public int MobileNo { get; set; }
        public string? EmailAddress { get; set; }
        [Required]
        public string? Provice { get; set; }
        [Required]
        public string? PermanentAddress { get; set; }
        [Required]
        public string? PostalAddress { get; set; }
        [Required]
        public byte[]? Photo { get; set; }
        [Required]
        public int FatherCNIC { get; set; }
        public int FamilyMonthlyIncome { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public bool? HafizEQuran { get; set; }
        public bool? MaritalStatus { get; set; }
        [Required]
        public int GuardianContactNo { get; set; }
        [Required]
        public string? Nationality { get; set; }
        public string? DomicileDistrict { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdateDate { get; set; }

        public Student MapDtoToModel(StudentDTO dto)
        {
            return new Student()
            {
                ID                   =dto.ID,
                LastName             =dto.LastName,
                FirstMidName         =dto.FirstMidName,
                EnrollmentDate       =dto.EnrollmentDate,
                CNICBform            =dto.CNICBform,
                FatherName           =dto.FatherName,
                FatherOccupation     =dto.FatherOccupation,
                Gender               =dto.Gender,
                Islam                =dto.Islam,
                BloodGroup           =dto.BloodGroup,
                MobileNo             =dto.MobileNo,
                EmailAddress         =dto.EmailAddress,
                Provice              =dto.Provice,
                PermanentAddress     =dto.PermanentAddress,
                PostalAddress        =dto.PostalAddress,
                Photo                =dto.Photo,
                FatherCNIC           =dto.FatherCNIC,
                FamilyMonthlyIncome  =dto.FamilyMonthlyIncome,
                DateOfBirth          =dto.DateOfBirth,
                HafizEQuran          =dto.HafizEQuran,
                MaritalStatus        =dto.MaritalStatus,
                GuardianContactNo    =dto.GuardianContactNo,
                Nationality          =dto.Nationality,
                DomicileDistrict     =dto.DomicileDistrict,
                CreateDate           =dto.CreateDate,
                UpdateDate           =dto.UpdateDate,

            };

        }
    }
}
