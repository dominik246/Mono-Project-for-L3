using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private PageRepositoryModel<IVehicleMakeServiceModel> _pageServiceModel;
        private FilterModel _filterModel;
        private SortModel _sortModel;

        public VehicleMakeController(IVehicleService vehicleService, PageRepositoryModel<IVehicleMakeServiceModel> pageServiceModel, FilterModel filterModel, SortModel sortModel)
        {
            _vehicleService = vehicleService;
            _pageServiceModel = pageServiceModel;
            _filterModel = filterModel;
            _sortModel = sortModel;
        }

        // GET: api/VehicleMake
        [HttpGet]
        public async Task<ActionResult<PageServiceModel<IVehicleMakeServiceModel>>> GetVehicleMakes()
        {
            var result = await _vehicleService.FindAsync(_filterModel, _pageServiceModel, _sortModel);
            return Ok(result);
        }

        // GET: api/VehicleMake/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IVehicleMakeServiceModel>> GetVehicleMakeServiceModel(int? id)
        {
            var vehicleMakeRepoModel = await _vehicleService.GetAsync<IVehicleMakeServiceModel>(id);

            if (vehicleMakeRepoModel == null)
            {
                return NotFound();
            }

            return Ok(vehicleMakeRepoModel);
        }

        // PUT: api/VehicleMake/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleMakeServiceModel(int id, IVehicleMakeServiceModel vehicleMakeServiceModel)
        {
            if (id != vehicleMakeServiceModel.Id)
            {
                return BadRequest();
            }

            await _vehicleService.UpdateAsync(vehicleMakeServiceModel);

            return NoContent();
        }

        // POST: api/VehicleMake
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IVehicleMakeServiceModel>> PostVehicleMakeRepoModel(IVehicleMakeServiceModel vehicleMakeServiceModel)
        {
            await _vehicleService.CreateAsync(vehicleMakeServiceModel);

            return CreatedAtAction("GetVehicleMakeServiceModel", new { id = vehicleMakeServiceModel.Id }, vehicleMakeServiceModel);
        }

        // DELETE: api/VehicleMake/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IVehicleMakeServiceModel>> DeleteVehicleMakeServiceModel(int id)
        {
            var vehicleMakeServiceModel = await _vehicleService.GetAsync<IVehicleMakeServiceModel>(id);
            if (vehicleMakeServiceModel == null)
            {
                return NotFound();
            }

            await _vehicleService.DeleteAsync<IVehicleMakeServiceModel>(id);

            return Ok(vehicleMakeServiceModel);
        }
    }
}
