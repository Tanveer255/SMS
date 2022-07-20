using SMS.Models.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.BLL.Services;
using SMS.Models.DTO;

namespace SMS.BLL.Interfaces
{
    public interface IStudentService: ICRUDService<Student>
    {
        //public Task<StudentDTO> CreateContact(StudentDTO dto);

    }
}
