// <copyright file="UnitOfWork.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1200 // Using directives should be placed correctly
using Microsoft.Extensions.Logging;
#pragma warning restore SA1200 // Using directives should be placed correctly
using SMS.DAL.Interface;
using SMS.Models.Data;


namespace SMS.DAL.Repository
{
    /// <summary>
    /// Class of UnitOfWork.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger<UnitOfWork> logger;
        /// <summary>
        /// Gets this is DBContext class.
        /// </summary>
        public ApplicationDbContext Context { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">object of ApplicationDbContext.</param>
        /// <param name="logger">object of ILogger.</param>
        public UnitOfWork(ApplicationDbContext context, ILogger<UnitOfWork> logger)
        {
            this.Context = context;
            this.logger = logger;
        }

        /// <summary>
        /// Commit save changes.
        /// </summary>
        public void Commit()
        {
            try
            {
                this.logger.LogInformation("Commit save changes");
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Dispose method.
        /// </summary>
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
