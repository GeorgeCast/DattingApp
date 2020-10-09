using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using APII.Entities;
using Microsoft.EntityFrameworkCore;

namespace APII.Data
{
    public class DataRepository<T> : IDataRepository<T> where T : EntityBase
    {

        public DataRepository(DataContext context) 
        {
            Context = context;
        }

        public DataContext Context { get; }

        public async Task<T> Create(T entity)
        {
            try
            { 
                await Context.AddAsync<T>(entity);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity;
        }

        public async Task<bool> Delete(T entity)
        {
            try
            { 
                Context.Remove<T>(entity);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public async Task<List<T>> FindAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().Where(expression).ToListAsync<T>();
        }

        public async Task<T> FindById(int id)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                Context.Update<T>(entity);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity;
        }
    }
}
