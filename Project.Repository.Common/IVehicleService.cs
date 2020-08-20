using Project.Common.Models;
using Project.Model.Common;

using System;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IVehicleService
    {
        Task CreateAsync<TModel>(TModel entity) where TModel : class;
        Task DeleteAsync<TModel>(int id) where TModel : class;
        Task<PageModel<TModel>> FindAsync<TModel>(FilterModel filter, PageModel<TModel> page, SortModel sort) where TModel : class, IVehicle;
        Task<TModel> GetAsync<TModel>(int? id) where TModel : class, IVehicle;
        Task UpdateAsync<TModel>(TModel entity) where TModel : class;
    }
}