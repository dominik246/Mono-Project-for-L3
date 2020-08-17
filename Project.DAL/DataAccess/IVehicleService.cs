using Project.DAL.Models;

using System.Threading.Tasks;

namespace Project.DAL.DataAccess
{
    public interface IVehicleService<TModel> where TModel : class, IVehicle
    {
        Task CreateAsync(TModel entity);
        Task DeleteAsync(int id);
        Task<PageModel<TModel>> FindAsync(FilterModel filter, PageModel<TModel> page, SortModel sort);
        Task<TModel> GetAsync(int? id);
        Task UpdateAsync(TModel entity);
    }
}