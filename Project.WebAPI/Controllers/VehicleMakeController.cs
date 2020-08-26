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
    public class VehicleMakeController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private PageRepositoryModel<VehicleMakeRepoModel> _pageServiceModel;
        private FilterModel _filterModel;
        private SortModel _sortModel;
        private IMapper _mapper;

        public VehicleMakeController(IVehicleService vehicleService, PageRepositoryModel<VehicleMakeRepoModel> pageServiceModel, FilterModel filterModel, SortModel sortModel, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _pageServiceModel = pageServiceModel;
            _filterModel = filterModel;
            _sortModel = sortModel;
            _mapper = mapper;
        }

        // GET: api/VehicleMake
        [HttpGet]
        public async Task<ActionResult<PageServiceModel<VehicleMakeServiceModel>>> GetVehicleMakes(int page = 1, string filter = "", string sortby = "Id")
        {
            _pageServiceModel.CurrentPageIndex = page;
            _filterModel.FilterString = filter;
            _sortModel.SortBy = sortby;
            var result = await _vehicleService.FindAsync(_filterModel, _pageServiceModel, _sortModel);
            var dto = _mapper.Map<PageServiceModel<VehicleMakeServiceModel>>(result);
            return dto;
        }

        // GET: api/VehicleMake/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleMakeServiceModel>> GetVehicleMakeServiceModel(int? id)
        {
            var vehicleMakeRepoModel = await _vehicleService.GetAsync<VehicleMakeRepoModel>(id);

            if (vehicleMakeRepoModel == null)
            {
                return NotFound();
            }
            var dto = _mapper.Map<VehicleMakeServiceModel>(vehicleMakeRepoModel);

            return Ok(dto);
        }

        // PUT: api/VehicleMake/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult> PutVehicleMakeServiceModel(int id, VehicleMakeServiceModel vehicleMakeServiceModel)
        {
            if (id != vehicleMakeServiceModel.Id)
            {
                return BadRequest();
            }
            var dto = _mapper.Map<VehicleMakeRepoModel>(vehicleMakeServiceModel);
            await _vehicleService.UpdateAsync(dto);

            return NoContent();
        }

        // POST: api/VehicleMake
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VehicleMakeServiceModel>> PostVehicleMakeRepoModel(VehicleMakeServiceModel vehicleMakeServiceModel)
        {
            var dto = _mapper.Map<VehicleMakeRepoModel>(vehicleMakeServiceModel);
            await _vehicleService.CreateAsync(dto);

            return CreatedAtAction("GetVehicleMakeServiceModel", new { id = vehicleMakeServiceModel.Id }, vehicleMakeServiceModel);
        }

        // DELETE: api/VehicleMake/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleMakeServiceModel>> DeleteVehicleMakeServiceModel(int id)
        {
            var vehicleMakeRepoModel = await _vehicleService.GetAsync<VehicleMakeRepoModel>(id);
            if (vehicleMakeRepoModel == null)
            {
                return NotFound();
            }
            await _vehicleService.DeleteAsync<VehicleMakeRepoModel>(id);
            var dto = _mapper.Map<VehicleMakeServiceModel>(vehicleMakeRepoModel);

            return Ok(dto);
        }
    }
}
