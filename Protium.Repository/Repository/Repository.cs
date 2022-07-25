using Microsoft.EntityFrameworkCore;
using Protium.Data;
using Protium.Data.BaseEntity;
using Protium.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protium.Repository.Repository
{

    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly DataContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(DataContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await entities.ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAll(string[] includes)
        {
            return await includes.Aggregate(entities.AsQueryable(), (query, path) => query.Include(path)).ToListAsync();
        }
        public async Task<T> Get(string id)
        {
            return await entities.SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<T> Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await context.SaveChangesAsync();
            return entity;
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }


    }
}
