using SMS.Models.Data.Models;
using SMS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.DAL.Interface
{
    /// <summary>
    /// Company Repository interface.
    /// </summary>
    public interface ICourseRepository : IRepository<Course>
    {
        /// <summary>
        /// Method for getting record.
        /// </summary>
        /// <returns>Returns total record.</returns>
        public Task<int> GetTotalCount();

        /// <summary>
        /// IsNameExist is an Method, for checking name is exist or not.
        /// </summary>
        /// <param name="name">Name is an object which passes name to this method.</param>
        /// <returns>Returns name after checking.</returns>
        public Task<bool> IsNameExist(string name);

        /// <summary>
        /// GetAll is an method to company.
        /// </summary>
        /// <param name="id">Id is an object of Guid.</param>
        /// <returns>Returns an Course names that iterates through the collection.</returns>
        public Task<IEnumerable<CourseDTO>> GetAll(Guid id);

        /// <summary>
        /// GetAllSearch is an method, for search company by id.
        /// </summary>
        /// <param name="dto">is an object of SearchCompanyDTO.</param>
        /// <returns>Returns an company names that iterates through the collection.</returns> public Task<IEnumerable<CourseDTO>> GetAll(Guid id);
        public Task<IEnumerable<CourseDTO>> GetCourses(Guid id);
        /// <summary>
        /// GetAllSearch is an method, for search company by id.
        /// </summary>
        /// <param name="dto">is an object of SearchCompanyDTO.</param>
        /// <returns>Returns an company names that iterates through the collection.</returns>
        public Task<IEnumerable<CourseDTO>> GetAllSearch(SearchCourseDTO dto);

        /// <summary>
        /// GetByClientCredential is an method, for getting client credentials.
        /// </summary>
        /// <param name="clientId">is an first parameter of GetByClientCredential.</param>
        /// <param name="clientSecret">is an second parameter of GetByClientCredential.</param>
        /// <returns>Returns Client Credential.</returns>
        public Task<Course> GetByClientCredential(string clientId, string clientSecret);

        /// <summary>
        /// GetByTenantId is an method, for getting user by Tenant Id.
        /// </summary>
        /// <param name="id">is an parameter which passes id.</param>
        /// <returns>Returns Course name.</returns>
        public Task<Course> GetByTenantId(string id);

        /// <summary>
        /// GetStaffCompany is an method, for getting Staff Company.
        /// </summary>
        /// <returns>Returns Course name.</returns>
        public Task<Course> GetStaffCompany();
    }
}
