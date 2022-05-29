using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using ESOC.CLTPull.Assessment.Core.Entities;
using Microsoft.EntityFrameworkCore;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Infrastructure.Data.Repositories.BaseW
{
    public class Repository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly CLTPULLContext _dbContext;

        public Repository(CLTPULLContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.CountAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return  await _dbContext.SaveChangesAsync();
        }

        public async Task<T> FirstAsync(ISpecification<T> spec)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.FirstAsync();
        }

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.FirstOrDefaultAsync();
        }

        //private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        //{
        //    var evaluator = new SpecificationEvaluator<T>();
        //    return evaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        //}
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            if (spec == null)
            {
                return _dbContext.Set<T>();
            }
            var query = SpecificationEvaluator.Default.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
            return spec is ISpecification<T, T> specFiltered ? query.Select(specFiltered.Selector) : query;
        }
    }
}
