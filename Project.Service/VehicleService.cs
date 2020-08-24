using AutoMapper;

using Project.Common.Models;
using Project.DAL;
using Project.Model;
using Project.Service.Common;

using System;
using System.Threading.Tasks;

namespace Project.Service
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync<TModel>(TModel entity) where TModel : class
        {
            try
            {
                await _unitOfWork.VehicleRepository.CreateAsync(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync<TModel>(int id) where TModel : class
        {
            try
            {
                await _unitOfWork.VehicleRepository.DeleteAsync<TModel>(id);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAsync<TModel>(TModel entity) where TModel : class
        {
            try
            {
                await _unitOfWork.VehicleRepository.UpdateAsync(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        public async Task<PageServiceModel<TModel>> FindAsync<TModel>(FilterModel filter, PageRepositoryModel<TModel> page, SortModel sort) where TModel : class, IVehicle
        {
            var result = await _unitOfWork.VehicleRepository.FindAsync(filter, page, sort);
            return _mapper.Map<PageServiceModel<TModel>>(result);
        }

        public async Task<TModel> GetAsync<TModel>(int? id) where TModel : class, IVehicle
        {
            return await _unitOfWork.VehicleRepository.GetAsync<TModel>(id);
        }
    }
}
