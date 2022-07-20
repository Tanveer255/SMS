using SMS.BLL.Interfaces;
using SMS.DAL.Interface;
using SMS.Models.Data;
using SMS.Models.Data.Models;
using SMS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.BLL.Services
{
    /// <summary>
    /// CourseService is defined to manage Company operations.
    /// </summary>
    public class CourseService : CRUDService<Course>, ICourseService
    {
        private readonly ICourseRepository companyRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ApplicationDbContext applicationDbContext;
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyService"/> class.
        /// </summary>
        /// <param name="companyRepository">Memeber of Course Service.</param>
        /// <param name="unitOfWork">Memeber of Course Sevice.</param>
        /// <param name="applicationDbContext">MEmeber of Course Service.</param>
        public CourseService(ICourseRepository companyRepository, IUnitOfWork unitOfWork, ApplicationDbContext applicationDbContext)
            : base(companyRepository, unitOfWork)
        {
            this.companyRepository = companyRepository;
            this.unitOfWork = unitOfWork;
            this.applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// Method of Company Service use to get the Company.
        /// </summary>
        /// <param name="id">Parameter to get the company by Id.</param>
        /// <returns>Company Object after getting.</returns>
        public async Task<Course>? GetById(Guid id)
        {
            applicationDbContext.ChangeTracker.AutoDetectChangesEnabled = false;
            return applicationDbContext.Courses.FirstOrDefault(c => c.CourseID == id);
        }

        /// <summary>
        /// Method of Company Service use to get the all CompanyDto.
        /// </summary>
        /// <param name="id">Parameter to get the CompanyDto.</param>
        /// <returns>List of CopnayDto objects.</returns>
        public async Task<IEnumerable<CourseDTO>> GetAll(Guid id)
        {
            return await companyRepository.GetAll(id);
        }

        /// <summary>
        /// Method of Company Service use to get the number of total Companies.
        /// </summary>
        /// <returns>Number of counting Company.</returns>
        public async Task<int> GetTotalCount()
        {
            return await companyRepository.GetTotalCount();
        }

        /// <summary>
        /// Method of Company Service use to update the Company.
        /// </summary>
        /// <param name="entity">Parameter is Company object need to be updated.</param>
        /// <returns>Company object after update.</returns>
        public override async Task<Course> Update(Course entity)
        {
            var entityFromDatabase = await GetById(entity.CourseID);
            //entityFromDatabase.Update(entity);
            await companyRepository.Update(entityFromDatabase);
            unitOfWork.Commit();
            return entityFromDatabase;
        }

        /// <summary>
        /// Method of Company Service use to save the image.
        /// </summary>
        /// <param name="id">Paramter of to get the Company.</param>
        /// <param name="imageId">Paramter to save the image.</param>
        /// <returns>True if save otherwise false.</returns>
        public async Task<bool> SaveImage(Guid id, Guid imageId)
        {
            var companyFromDatabase = await companyRepository.GetSingle(u => u.CourseID == id);
            //companyFromDatabase.ImageId = imageId;
            await companyRepository.Update(companyFromDatabase);
            unitOfWork.Commit();
            return await Task.FromResult(true);
        }

        /// <summary>
        /// Method of Company Service use to check that company name already exist or not.
        /// </summary>
        /// <param name="name">Paramter as company name need to be check.</param>
        /// <returns>True if name is already exist otherwise false.</returns>
        public async Task<bool> IsNameExist(string name)
        {
            return await companyRepository.IsNameExist(name);
        }

        /// <summary>
        /// Method of Company Service use to search the Company Dto.
        /// </summary>
        /// <param name="dto">Object need to be search.</param>
        /// <returns>List of Company Dto after fetching.</returns>
        public async Task<IEnumerable<CourseDTO>> GetAllSearch(SearchCourseDTO dto)
        {
            return await companyRepository.GetAllSearch(dto);
        }

        /// <summary>
        /// Method of Company Service use to get Company by client credential.
        /// </summary>
        /// <param name="clientId">Paramter to find the company.</param>
        /// <param name="clientSecret">PAramter to find the company.</param>
        /// <returns>Company object after fetching.</returns>
        public async Task<Course> GetByClientCredential(string clientId, string clientSecret)
        {
            return await companyRepository.GetByClientCredential(clientId, clientSecret);
        }

        /// <summary>
        /// Method of Company Service use to get Company on id base.
        /// </summary>
        /// <param name="id">Paramter to find the company.</param>
        /// <returns>Company object after fetching.</returns>
        public async Task<Course> GetByTenantId(string id)
        {
            return await companyRepository.GetByTenantId(id);
        }

        /// <summary>
        /// Method of Company Service use to get staff Company.
        /// </summary>
        /// <returns>Company object after fetching.</returns>
        public async Task<Course> GetStaffCompany()
        {
            return await companyRepository.GetStaffCompany();
        }
    }
}
