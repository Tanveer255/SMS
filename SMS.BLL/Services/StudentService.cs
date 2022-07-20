using Microsoft.Extensions.Logging;
using SMS.BLL.Interfaces;
using SMS.DAL.Interface;
using SMS.Models.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.BLL.Services
{
    public  class StudentService : CRUDService<Student>,IStudentService
    {
        private readonly ILogger<StudentService> logger;
        private readonly IStudentRepositorey studentRepositorey;
        public StudentService(IStudentRepositorey studentRepositorey, IUnitOfWork unitOfWork, ILogger<StudentService> logger) : base(studentRepositorey, unitOfWork)
        {
            this.logger = logger;
            this.studentRepositorey = studentRepositorey;
        }
    }
}
