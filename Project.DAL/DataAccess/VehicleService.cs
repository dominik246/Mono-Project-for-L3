using Microsoft.EntityFrameworkCore;

using Project.Common.Models;
using Project.DAL.DataAccess.Extensions;
using Project.DAL.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Project.DAL.DataAccess
{
    public class VehicleService : IVehicleService
    {
        private readonly IServiceDbContext _dbContext;
        public VehicleService(IServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PageModel<TModel>> FindAsync<TModel>(FilterModel filter, PageModel<TModel> page, SortModel sort) where TModel : class, IVehicle
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

        public async Task<TModel> GetAsync<TModel>(int? id) where TModel : class, IVehicle
        {
            return await _dbContext.Set<TModel>().IncludeAll(_dbContext).AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task CreateAsync<TModel>(TModel entity) where TModel : class
        {
            await _dbContext.Set<TModel>().AddAsync(entity);
        }

        public async Task UpdateAsync<TModel>(TModel entity) where TModel : class
        {
            await Task.Run(() => _dbContext.Set<TModel>().Update(entity));
        }

        public async Task DeleteAsync<TModel>(int id) where TModel : class
        {
            var entity = await _dbContext.Set<TModel>().FindAsync(id);

            if (entity != null)
            {
                await Task.Run(() => _dbContext.Set<TModel>().Remove(entity));
            }
        }
    }
}
