// <copyright file="Repository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/// <summary>
/// Header
/// </summary>
/// <typeparam name="Header">is an object of IRepository.</typeparam>

namespace SMS.DAL.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using SMS.DAL.Interface;

    /// <summary>
    /// Repository class.
    /// </summary>
    /// <typeparam name="T">is an object of IRepository.</typeparam>
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<Repository<T>> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="unitOfWork">is an object of IUnitOfWork.</param>
        /// <param name="logger">is an object of ILogger.</param>
        public Repository(IUnitOfWork unitOfWork, ILogger<Repository<T>> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        /// <summary>
        /// Method for adding.
        /// </summary>
        /// <param name="entity">is an entity model.</param>
        /// <returns>Returns result.</returns>
        public async Task Add(T entity)
        {
            try
            {
                this.logger.LogInformation("Adding:" + entity);
                var savedEntity = this.unitOfWork.Context.Set<T>().Add(entity);
                await Task.FromResult(savedEntity.Entity);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Method for deleting.
        /// </summary>
        /// <param name="entity">is an entity model.</param>
        /// <returns>Returns result.</returns>
        public async Task Delete(T entity)
        {
            try
            {
                this.logger.LogInformation("Deleting:" + entity);
                var savedEntity = this.unitOfWork.Context.Set<T>().Remove(entity);
                await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Method for getting.
        /// </summary>
        /// <returns>Returns result.</returns>
        public async Task<IEnumerable<T>> Get()
        {
            try
            {
                this.logger.LogInformation("Getting list.");
                var entityList = this.unitOfWork.Context.Set<T>().ToList();
                return await Task.FromResult(entityList);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Method for getting single item.
        /// </summary>
        /// <param name="predicate">param check weather.</param>
        /// <returns>Returns result.</returns>
        public async Task<T> GetSingle(Expression<Func<T, bool>> predicate)
        {
            try
            {
                this.logger.LogInformation("Getting single:" + predicate);
                var entity = this.unitOfWork.Context.Set<T>().FirstOrDefault(predicate);
#pragma warning disable CS8603 // Possible null reference return.
                return await Task.FromResult(entity);
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Method for getting.
        /// </summary>
        /// <param name="predicate">param check weather.</param>
        /// <returns>Returns result.</returns>
        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            try
            {
                this.logger.LogInformation("Getting:" + predicate);
                var entityList = this.unitOfWork.Context.Set<T>().Where(predicate).ToList();
                return await Task.FromResult(entityList);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Method for updating.
        /// </summary>
        /// <param name="entity">is an entity model.</param>
        /// <returns>Returns result.</returns>
        public async Task Update(T entity)
        {
            try
            {
                this.logger.LogInformation("Updating:" + entity);
                var savedEntity = this.unitOfWork.Context.Set<T>().Update(entity);
                await Task.FromResult(savedEntity.Entity);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Method for adding list.
        /// </summary>
        /// <param name="entities">is a list of entity model.</param>
        /// <returns>Returns result.</returns>
        public async Task Add(IEnumerable<T> entities)
        {
            try
            {
                this.logger.LogInformation("Adding list." + entities);
                foreach (var entity in entities)
                {
                    this.unitOfWork.Context.Set<T>().Add(entity);
                }

                await Task.FromResult(entities);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Method for deleting list.
        /// </summary>
        /// <param name="entities">is a list of entity model.</param>
        /// <returns>Returns result.</returns>
        public async Task Delete(IEnumerable<T> entities)
        {
            try
            {
                this.logger.LogInformation("Deleting list." + entities);
                foreach (var entity in entities)
                {
                    this.unitOfWork.Context.Set<T>().Remove(entity);
                }

                await Task.FromResult(entities);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Method for updating list.
        /// </summary>
        /// <param name="entities">is an entity model.</param>
        /// <returns>Returns result.</returns>
        public async Task Update(IEnumerable<T> entities)
        {
            try
            {
                this.logger.LogInformation("Updating list." + entities);
                foreach (var entity in entities)
                {
                    this.unitOfWork.Context.Set<T>().Update(entity);
                }

                await Task.FromResult(entities);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
