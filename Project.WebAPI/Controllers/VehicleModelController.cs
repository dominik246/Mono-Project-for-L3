using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Project.Common.Models;
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using Project.Service.Common;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private PageRepositoryModel<VehicleModelRepoModel> _pageServiceModel;
        private FilterModel _filterModel;
        private SortModel _sortModel;
        private IMapper _mapper;

        public VehicleModelController(IVehicleService vehicleService, PageRepositoryModel<VehicleModelRepoModel> pageServiceModel, FilterModel filterModel, SortModel sortModel, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _pageServiceModel = pageServiceModel;
            _filterModel = filterModel;
            _sortModel = sortModel;
            _mapper = mapper;
        }

        // GET: api/VehicleModel
        [HttpGet]
        public async Task<ActionResult<PageServiceModel<VehicleModelRepoModel>>> GetVehicleModels(int page = 1, string filter = "", string sortby = "Id")
        {
            _pageServiceModel.CurrentPageIndex = page;
            _filterModel.FilterString = filter;
            _sortModel.SortBy = sortby;
            return await _vehicleService.FindAsync(_filterModel, _pageServiceModel, _sortModel);
        }

        // GET: api/VehicleModel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleModelServiceModel>> GetVehicleModelServiceModel(int id)
        {
            var result = await _vehicleService.GetAsync<VehicleModelRepoModel>(id);

            if (result == null)
            {
                return NotFound();
            }
            var dto = _mapper.Map<VehicleModelServiceModel>(result);

            return Ok(dto);
        }

        // PUT: api/VehicleModel/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult> PutVehicleModelServiceModel(int id, VehicleModelServiceModel vehicleModelServiceModel)
        {
            if (id != vehicleModelServiceModel.Id)
            {
                return BadRequest();
            }
            var dto = _mapper.Map<VehicleModelRepoModel>(vehicleModelServiceModel);
            await _vehicleService.UpdateAsync(dto);

            return NoContent();
        }

        // POST: api/VehicleModel
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VehicleModelServiceModel>> PostVehicleModelServiceModel(VehicleModelServiceModel vehicleModelServiceModel)
        {
            var dto = _mapper.Map<VehicleModelRepoModel>(vehicleModelServiceModel);
            await _vehicleService.CreateAsync(dto);

            return CreatedAtAction("GetVehicleModelServiceModel", new { id = vehicleModelServiceModel.Id }, vehicleModelServiceModel);
        }

        // DELETE: api/VehicleModel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleModelServiceModel>> DeleteVehicleModelServiceModel(int id)
        {
            var vehicleModelRepoModel = await _vehicleService.GetAsync<VehicleModelRepoModel>(id);
            if (vehicleModelRepoModel == null)
            {
                return NotFound();
            }

            await _vehicleService.DeleteAsync<VehicleModelRepoModel>(id);
            var dto = _mapper.Map<VehicleModelServiceModel>(vehicleModelRepoModel);

            return Ok(dto);
        }
    }
}
