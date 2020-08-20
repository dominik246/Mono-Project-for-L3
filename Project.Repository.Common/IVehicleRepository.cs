using Project.Common.Models;
using Project.Model.Common;

using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IVehicleRepository
    {
        Task CreateAsync<TModel>(TModel entity) where TModel : class;
        Task DeleteAsync<TModel>(int id) where TModel : class;
        Task<PageRepositoryModel<TModel>> FindAsync<TModel>(FilterModel filter, PageRepositoryModel<TModel> page, SortModel sort) where TModel : class, IVehicle;
        Task<TModel> GetAsync<TModel>(int? id) where TModel : class, IVehicle;
        Task UpdateAsync<TModel>(TModel entity) where TModel : class;
    }
}