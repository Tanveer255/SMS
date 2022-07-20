namespace SMS.DAL.Repository
{
    using Microsoft.Extensions.Logging;
    using SMS.DAL.Interface;
    using SMS.Models.Data.Models;
    using SMS.Models.DTO;

    /// <summary>
    /// Class for Course Repository.
    /// </summary>
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<CourseRepository> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseRepository"/> class.
        /// Constructor of CompanyRepository containing parameters.
        /// </summary>
        /// <param name="unitOfWork">First param which holds unit of work interface.</param>
        /// <param name="logger">Second param, which holds logging information.</param>
        /// <param name="countryRepository">Fourth param,  Country Repository interface.</param>
        public CourseRepository(IUnitOfWork unitOfWork, ILogger<CourseRepository> logger)
            : base(unitOfWork, logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        /// <summary>
        /// Get is an method, for Getting list of companies.
        /// </summary>
        /// <returns>Returns Company model.</returns>
        public new async Task<IEnumerable<Course>> Get()
        {
            IEnumerable<Course> courses = new List<Course>();
            try
            {
                logger.LogInformation("Getting list of courses.");
                courses = (
                from c in unitOfWork.Context.Courses
                select c).ToList().GroupBy(c => c.CourseID, c => c, (key, c) => c.FirstOrDefault());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                throw new Exception(ex.Message, ex.InnerException);
            }

            logger.LogInformation("Returning list of companies:" + courses);
            return await Task.FromResult(courses);
        }

        /// <summary>
        /// GetAll is an method, for Getting list of all companies.
        /// </summary>
        /// <param name="id">Containing company id. </param>
        /// <returns>Returns GetCompanyDTO model.</returns>
        public async Task<IEnumerable<CourseDTO>> GetAll(Guid id)
        {
            List<CourseDTO> courses = new List<CourseDTO>();
            try
            {
                courses = unitOfWork.Context.Courses.Where(c => c.CourseID != id).OrderByDescending(c => c.UpdateTimeStamp).Select(c => new CourseDTO() { CourseID = c.CourseID, Title = c.Title, Credits = c.Credits, UpdateTimeStamp = c.UpdateTimeStamp }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return await Task.FromResult(courses);
        }

        /// <summary>
        /// GetAllSearch is an method, for Getting all  companies not included curent logged in company id.
        /// </summary>
        /// <param name="dto">is an object of SearchCompanyDTO.</param>
        /// <returns>Returns GetCompanyDTO model.</returns>
        //public async Task<IEnumerable<CourseDTO>> GetAllSearch(SearchCourseDTO dto)
        //{
        //    IEnumerable<CourseDTO> courses = new List<CourseDTO>();
        //    try
        //    {
        //        this.logger.LogInformation("Getting all  courses not included curent logged in company id:" + dto.CourseID.ToString());
        //        IQueryable<CourseDTO> coursesData = Enumerable.Empty<CourseDTO>().AsQueryable();
        //        if (!string.IsNullOrEmpty(dto.Query))
        //        {
                   
        //            List<string> countryCodeList = courses
        //                                          .Where(ctry => ctry.Title.ToLower().Contains(query) || ctry.AlphaTwoCode.ToLower().Contains(query) || ctry.AlphaThreeCode.ToLower().Contains(query))
        //                                          .Select(ctry => ctry.AlphaTwoCode)
        //                                          .ToList();
        //            if (idsList == null)
        //            {
        //                idsList = new List<Guid>();
        //            }

        //            if (countryCodeList == null)
        //            {
        //                countryCodeList = new List<string>();
        //            }

        //            if (idsList.Count > 0 && countryCodeList.Count > 0)
        //            {
        //                companiessData = (from c in _unitOfWork.Context.Companies
        //                                  where (c.Id != dto.CompanyId && idsList.Contains(c.Id)) || countryCodeList.Contains(c.Country) ||
        //                                 (c.TenantId.ToLower().Contains(query) ||
        //                                  c.Name.ToLower().Contains(query))
        //                                  select new GetCompanyDTO()
        //                                  {
        //                                      Id = c.Id,
        //                                      Name = c.Name,
        //                                      TenantId = c.TenantId,
        //                                      Country = c.Country,
        //                                      CreatedTimeStamp = c.CreatedTimeStamp,
        //                                      UpdatedTimeStamp = c.UpdatedTimeStamp,
        //                                      UsersCount = _unitOfWork.Context.Users.Where(u => u.CompanyId == c.Id && !u.IsDeleted).Count(),
        //                                  });
        //            }
        //            else if (idsList.Count > 0)
        //            {
        //                companiessData = (from c in _unitOfWork.Context.Companies
        //                                  where (c.Id != dto.CompanyId && idsList.Contains(c.Id)) ||
        //                                 (c.TenantId.ToLower().Contains(query) ||
        //                                  c.Name.ToLower().Contains(query))
        //                                  select new GetCompanyDTO()
        //                                  {
        //                                      Id = c.Id,
        //                                      Name = c.Name,
        //                                      TenantId = c.TenantId,
        //                                      Country = c.Country,
        //                                      CreatedTimeStamp = c.CreatedTimeStamp,
        //                                      UpdatedTimeStamp = c.UpdatedTimeStamp,
        //                                      UsersCount = _unitOfWork.Context.Users.Where(u => u.CompanyId == c.Id && !u.IsDeleted).Count(),
        //                                  });
        //            }
        //            else if (countryCodeList.Count > 0)
        //            {
        //                companiessData = (from c in _unitOfWork.Context.Companies
        //                                  where (c.Id != dto.CompanyId && countryCodeList.Contains(c.Country)) ||
        //                                 (c.TenantId.ToLower().Contains(query) ||
        //                                  c.Name.ToLower().Contains(query))
        //                                  select new GetCompanyDTO()
        //                                  {
        //                                      Id = c.Id,
        //                                      Name = c.Name,
        //                                      TenantId = c.TenantId,
        //                                      Country = c.Country,
        //                                      CreatedTimeStamp = c.CreatedTimeStamp,
        //                                      UpdatedTimeStamp = c.UpdatedTimeStamp,
        //                                      UsersCount = _unitOfWork.Context.Users.Where(u => u.CompanyId == c.Id && !u.IsDeleted).Count(),
        //                                  });
        //            }
        //            else
        //            {
        //                companiessData = (from c in _unitOfWork.Context.Companies
        //                                  where c.Id != dto.CompanyId &&
        //                                 (c.TenantId.ToLower().Contains(query) ||
        //                                  c.Name.ToLower().Contains(query))
        //                                  select new GetCompanyDTO()
        //                                  {
        //                                      Id = c.Id,
        //                                      Name = c.Name,
        //                                      TenantId = c.TenantId,
        //                                      Country = c.Country,
        //                                      CreatedTimeStamp = c.CreatedTimeStamp,
        //                                      UpdatedTimeStamp = c.UpdatedTimeStamp,
        //                                      UsersCount = _unitOfWork.Context.Users.Where(u => u.CompanyId == c.Id && !u.IsDeleted).Count(),
        //                                  });
        //            }
        //        }
        //        else
        //        {
        //            companiessData = (from c in _unitOfWork.Context.Companies
        //                              where c.Id != dto.CompanyId
        //                              select new GetCompanyDTO()
        //                              {
        //                                  Id = c.Id,
        //                                  Name = c.Name,
        //                                  TenantId = c.TenantId,
        //                                  Country = c.Country,
        //                                  CreatedTimeStamp = c.CreatedTimeStamp,
        //                                  UpdatedTimeStamp = c.UpdatedTimeStamp,
        //                                  UsersCount = _unitOfWork.Context.Users.Where(u => u.CompanyId == c.Id && !u.IsDeleted).Count(),
        //                              });
        //        }

        //        dto.TotalRecords = companiessData.Count();
        //        dto.TotalFilteredRecords = companiessData.Count();
        //        if ((int)dto.Column != 0)
        //        {
        //            if (dto.Order == Enums.Order.asc.ToString())
        //            {
        //                if (dto.Column == Enums.CompanyColumns.TenantId)
        //                {
        //                    companiessData = companiessData.OrderBy(c => c.TenantId).Skip(dto.Start).Take(dto.PageSize);
        //                }

        //                if (dto.Column == Enums.CompanyColumns.Name)
        //                {
        //                    companiessData = companiessData.OrderBy(c => c.Name.ToLower().Trim()).Skip(dto.Start).Take(dto.PageSize);
        //                }

        //                if (dto.Column == Enums.CompanyColumns.Country)
        //                {
        //                    companiessData = companiessData.OrderBy(c => c.Country).Skip(dto.Start).Take(dto.PageSize);
        //                }

        //                if (dto.Column == Enums.CompanyColumns.CreatedDate)
        //                {
        //                    companiessData = companiessData.OrderBy(u => u.CreatedTimeStamp).Skip(dto.Start).Take(dto.PageSize);
        //                }

        //                if (dto.Column == Enums.CompanyColumns.UpdatedDate)
        //                {
        //                    companiessData = companiessData.OrderBy(u => u.UpdatedTimeStamp).Skip(dto.Start).Take(dto.PageSize);
        //                }

        //                if (dto.Column == Enums.CompanyColumns.UsersCount)
        //                {
        //                    companiessData = companiessData.OrderBy(u => u.UsersCount).Skip(dto.Start).Take(dto.PageSize);
        //                }
        //            }
        //            else if (dto.Order == Enums.Order.desc.ToString())
        //            {
        //                if (dto.Column == Enums.CompanyColumns.TenantId)
        //                {
        //                    companiessData = companiessData.OrderByDescending(c => c.TenantId).Skip(dto.Start).Take(dto.PageSize);
        //                }

        //                if (dto.Column == Enums.CompanyColumns.Name)
        //                {
        //                    companiessData = companiessData.OrderByDescending(c => c.Name.ToLower().Trim()).Skip(dto.Start).Take(dto.PageSize);
        //                }

        //                if (dto.Column == Enums.CompanyColumns.Country)
        //                {
        //                    companiessData = companiessData.OrderByDescending(c => c.Country).Skip(dto.Start).Take(dto.PageSize);
        //                }

        //                if (dto.Column == Enums.CompanyColumns.CreatedDate)
        //                {
        //                    companiessData = companiessData.OrderByDescending(u => u.CreatedTimeStamp).Skip(dto.Start).Take(dto.PageSize);
        //                }

        //                if (dto.Column == Enums.CompanyColumns.UpdatedDate)
        //                {
        //                    companiessData = companiessData.OrderByDescending(u => u.UpdatedTimeStamp).Skip(dto.Start).Take(dto.PageSize);
        //                }

        //                if (dto.Column == Enums.CompanyColumns.UsersCount)
        //                {
        //                    companiessData = companiessData.OrderByDescending(u => u.UsersCount).Skip(dto.Start).Take(dto.PageSize);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (dto.Start == 0 && dto.PageSize == 0)
        //            {
        //                companiessData = companiessData.OrderByDescending(u => u.UpdatedTimeStamp);
        //            }
        //            else
        //            {
        //                companiessData = companiessData.OrderByDescending(u => u.UpdatedTimeStamp).Skip(dto.Start).Take(dto.PageSize);
        //            }
        //        }

        //        dto.Records = companiessData.ToList();
        //        companies = dto.Records;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
        //        throw new Exception(ex.Message, ex.InnerException);
        //    }

        //    _logger.LogInformation("Returning companies:" + companies + " not included company id:" + dto.CompanyId);
        //    return await Task.FromResult(companies);
        //}

        /// <summary>
        /// GetByClientCredential is an method, for Getting company detail from client and secret key.
        /// </summary>
        /// <param name="clientId">First param, which hold client id.</param>
        /// <param name="clientSecret">Second param, which hold client secret.</param>
        /// <returns>Returns compnmay data model.</returns>
        //public async Task<Course> GetByClientCredential(string clientId, string clientSecret)
        //{
        //    Course company = new Course();
        //    try
        //    {
        //        this.logger.LogInformation("Getting course detail from client and secret key.");
        //        company = (from credential in unitOfWork.Context.Courses
        //                   where credential.CourseID == clientId && credential.ClientSecret == clientSecret
        //                   select credential.Company).FirstOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex.InnerException);
        //    }

        //    return await Task.FromResult(company);
        //}

        /// <summary>
        /// GetByTenantId is an method, for Getting company detail from client and secret key.
        /// </summary>
        /// <param name="id">Which holds tenant id.</param>
        /// <returns>Returns compmay data model.</returns>
        public async Task<Course> GetByTenantId(string id)
        {
            Course course = new Course();
            try
            {
                this.logger.LogInformation("Getting course detail from client and secret key.");
                //course = (from Course in this.unitOfWork.Context.Courses
                //           where Course.CourseID == id
                //           select Course).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return await Task.FromResult(course);
        }

        /// <summary>
        /// GetTotalCount is an method, for Getting total count of companies.
        /// </summary>
        /// <returns>Returns total record result.</returns>
        public async Task<int> GetTotalCount()
        {
            var totalRecords = 0;
            try
            {
                this.logger.LogInformation("Getting total count of courses.");
                totalRecords = unitOfWork.Context.Courses.Count(c => c.CourseID != null);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                throw new Exception(ex.Message, ex.InnerException);
            }

            this.logger.LogInformation("Returning total count of courses.");
            return await Task.FromResult(totalRecords);
        }

        /// <summary>
        /// IsNameExist is an method, Checking is company exist.
        /// </summary>
        /// <param name="name">which holds company name.</param>
        /// <returns>Returns company name from result.</returns>
        public async Task<bool> IsNameExist(string name)
        {
            var isExist = false;
            try
            {
                this.logger.LogInformation("Checking is company exist - courses:" + name);
                isExist = (from c in unitOfWork.Context.Courses
                           where c.Title.ToLower().Equals(name.ToLower())
                           select c).ToList().Count() > 0;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                throw new Exception(ex.Message, ex.InnerException);
            }

            this.logger.LogInformation("Returning is courses exist - IsExist:" + isExist);
            return await Task.FromResult(isExist);
        }

        /// <summary>
        /// GetStaffCompany is an method, for Getting list of companies.
        /// </summary>
        /// <returns>Returns Company model.</returns>
        public async Task<Course> GetStaffCompany()
        {
            Course course = null;
            try
            {
                //this.logger.LogInformation("Getting list of companies.");
                //company = (
                //from c in unitOfWork.Context.Courses
                //join u in unitOfWork.Context.Users on c.Id equals u.CompanyId
                //join ur in unitOfWork.Context.UserRoles on u.Id equals ur.UserId
                //join r in unitOfWork.Context.Roles on ur.RoleId equals r.Id
                //where r.Name == Enums.Role.Supervisor.ToString()
                //select c).ToList().GroupBy(c => c.Id, c => c, (key, c) => c.FirstOrDefault()).FirstOrDefault();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                throw new Exception(ex.Message, ex.InnerException);
            }

            this.logger.LogInformation("Returning Staff company:" + course);
            return await Task.FromResult(course);
        }

        public Task<IEnumerable<CourseDTO>> GetCourses(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseDTO>> GetAllSearch(SearchCourseDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetByClientCredential(string clientId, string clientSecret)
        {
            throw new NotImplementedException();
        }
    }
}
