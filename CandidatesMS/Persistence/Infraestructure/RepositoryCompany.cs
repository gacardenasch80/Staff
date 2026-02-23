using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class RepositoryCompany<TEntity> : IRepositoryCompany<TEntity> where TEntity : class
    {
        protected readonly CompanyContext _context;
        protected readonly DbSet<TEntity> _entities;

        public RepositoryCompany(CompanyContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public async Task<TEntity> GetById(int id)
        {
            var candidate = await _entities.FindAsync(id);
            return candidate;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<bool> Add(TEntity entity)
        {
            await _entities.AddAsync(entity);
            int states = await _context.SaveChangesAsync();

            if (states != 0)
                return true;

            return false;
        }

        public async Task<bool> AddRange(IEnumerable<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities);
            int states = _context.SaveChanges();

            if (states != 0)
                return true;

            return false;
        }

        public async Task<bool> Update(TEntity entity)
        {
            var updated = _entities.Update(entity);
            int states = await _context.SaveChangesAsync();
            if (states != 0)
                return true;

            return false;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
            _context.SaveChanges();
        }

        public async Task<TEntity> Remove(int entityId)
        {
            var entity = await _entities.FindAsync(entityId);
            if (entity != null)
            {
                _entities.Remove(entity);
                var states = await _context.SaveChangesAsync();
                if (states != 0)
                    return entity;
            }
            return null;
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
            _context.SaveChanges();
        }
    }
}
