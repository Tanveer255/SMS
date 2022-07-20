using Microsoft.Extensions.Logging;
using SMS.DAL.Interface;
using SMS.Models.Data.Models;

namespace SMS.DAL.Repository
{
    public class StudentRepositorey : Repository<Student>, IStudentRepositorey
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<StudentRepositorey> logger;

        /// <summary>
        /// Initializes a new instance of the  <see cref="AddressRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork">is an object of IUnitOfWork.</param>
        /// <param name="logger">is an object of ILogger.</param>
        public StudentRepositorey(IUnitOfWork unitOfWork, ILogger<StudentRepositorey> logger)
            : base(unitOfWork, logger)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> IsOrgnasationNameExist(string name, string category)
        {
            var isExist = false;
            try
            {
                this.logger.LogInformation("Checking is Organisation exist - Organisation:" + name);
                isExist = (from c in this.unitOfWork.Context.Students
                           where c.FirstMidName.ToLower().Equals(name.ToLower())
                           && c.FatherName.ToLower().Equals(category.ToLower())
                           select c).ToList()
                           .Count() > 0;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                throw new Exception(ex.Message, ex.InnerException);
            }

            this.logger.LogInformation("Returning is Orgnasation exist - IsExist:" + isExist);
            return await Task.FromResult(isExist);
        }
    }
}
