 using System;
 using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;
using SMS.Models.Data.Models;

 namespace SMS.DAL.Interface
 {
     public interface IStudentRepositorey : IRepository<Student>
     {

        /// <summary>
        /// IsOrgnasationNameExist is an Method, for checking name is exist or not.
        /// </summary>
        /// <param name="name">Name is an object which passes name to this method.</param>
        /// <returns>Returns name after checking.</returns>
        public Task<bool> IsOrgnasationNameExist(string name, string category);
     }
 }
