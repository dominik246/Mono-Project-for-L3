using Microsoft.EntityFrameworkCore;

using Project.Common.Models;
using Project.DAL.DataAccess.Extensions;
using Project.DAL.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.DataAccess
{
    public class VehicleService<TModel> : IVehicleService<TModel> where TModel : class, IVehicle
    {
        private readonly IServiceDbContext _dbContext;
        public VehicleService(IServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PageModel<TModel>> FindAsync(FilterModel filter, PageModel<TModel> page, SortModel sort)
        {
            page ??= new PageModel<TModel>() { ReturnPaged = false };
            page.QueryResult = await Task.FromResult(_dbContext.Set<TModel>().IncludeAll(_dbContext)
                .GetSorted(sort).GetFiltered(filter).AsNoTracking());

            if (page.ReturnPaged)
            {
                page.CurrentRowCount = page.QueryResult.Count();
                page.QueryResult = page.QueryResult.GetPaged(page).QueryResult;
                page.TotalPageCount = page.TotalPageCount;
            }

            return page;
        }

        public async Task<TModel> GetAsync(int? id)
        {
            return await _dbContext.Set<TModel>().IncludeAll(_dbContext).AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task CreateAsync(TModel entity)
        {
            await _dbContext.Set<TModel>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TModel entity)
        {
            await Task.Run(() => _dbContext.Set<TModel>().Update(entity));
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<TModel>().FindAsync(id);

            if (entity != null)
            {
                await Task.Run(() => _dbContext.Set<TModel>().Remove(entity));
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
