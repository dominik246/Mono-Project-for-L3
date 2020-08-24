using Project.Common.Models;
using Project.Model;

using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleService
    {
        Task CreateAsync<TModel>(TModel entity) where TModel : class;
        Task DeleteAsync<TModel>(int id) where TModel : class;
        Task<PageServiceModel<TModel>> FindAsync<TModel>(FilterModel filter, PageRepositoryModel<TModel> page, SortModel sort) where TModel : class, IVehicle;
        Task<TModel> GetAsync<TModel>(int? id) where TModel : class, IVehicle;
        Task UpdateAsync<TModel>(TModel entity) where TModel : class;
    }
}
