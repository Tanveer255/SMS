using SMS.Models.Data.Models;
using SMS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.BLL.Interfaces
{
    /// <summary>
    /// Course services interface.
    /// </summary>
    public interface ICourseService:ICRUDService<Course>
    {
        /// <summary>
        /// Method declration of ICompanyService to get the Company.
        /// </summary>
        /// <param name="id">Object of getting Company.</param>
        /// <returns>Object of Course.</returns>

        public Task<Course> GetById(Guid id);
        /// <summary>
        /// Method declration of ICompanyService to get the list of CompanyDTO.
        /// </summary>
        /// <param name="id">Object of getting CompanyDTO.</param>
        /// <returns>List of CourseDTO.</returns>
        public Task<IEnumerable<CourseDTO>> GetAll(Guid id);

        /// <summary>
        /// Method declration of ICompanyService to count the Company.
        /// </summary>
        /// <returns>Number of counting.</returns>
        public Task<int> GetTotalCount();

        /// <summary>
        /// Method declration of ICompanyService to save the Image.
        /// </summary>
        /// <param name="id">Paramter of Company.</param>
        /// <param name="imageId">Paramter of Image.</param>
        /// <returns>True if save the Image otherwise false.</returns>
        public Task<bool> SaveImage(Guid id, Guid imageId);

        /// <summary>
        /// Method declration of ICompanyService to check that name is already exist.
        /// </summary>
        /// <param name="name">Paramter for checking.</param>
        /// <returns>True if already exist otherwise false.</returns>
        public Task<bool> IsNameExist(string name);

        /// <summary>
        /// Method declration of ICompanyService to search the CompanyDTO.
        /// </summary>
        /// <param name="dto">Object for search.</param>
        /// <returns>List of CompanyDTO.</returns>
        public Task<IEnumerable<CourseDTO>> GetAllSearch(SearchCourseDTO dto);

        /// <summary>
        /// Method declration of ICompanyService to get the Company.
        /// </summary>
        /// <param name="clientId">Paramter to get the Company.</param>
        /// <param name="clientSecret">Parameter to get the Company.</param>
        /// <returns>Course Object after getting.</returns>
        public Task<Course> GetByClientCredential(string clientId, string clientSecret);

        /// <summary>
        /// Method declration of ICompanyService to get the Company.
        /// </summary>
        /// <param name="id">Parameter to get the Company.</param>
        /// <returns>Course Object after getting.</returns>
        public Task<Course> GetByTenantId(string id);

        /// <summary>
        /// Method declration of ICompanyService to get the staff Company.
        /// </summary>
        /// <returns>Course Object after getting.</returns>
        public Task<Course> GetStaffCompany();
    }
}
