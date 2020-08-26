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
    public class VehicleModelController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private PageRepositoryModel<VehicleModelRepoModel> _pageServiceModel;
        private FilterModel _filterModel;
        private SortModel _sortModel;

        public VehicleModelController(IVehicleService vehicleService, PageRepositoryModel<VehicleModelRepoModel> pageServiceModel, FilterModel filterModel, SortModel sortModel)
        {
            _vehicleService = vehicleService;
            _pageServiceModel = pageServiceModel;
            _filterModel = filterModel;
            _sortModel = sortModel;
        }

        // GET: api/VehicleModel
        [HttpGet]
        public async Task<ActionResult<PageServiceModel<VehicleModelRepoModel>>> GetVehicleModels()
        {
            return await _vehicleService.FindAsync(_filterModel, _pageServiceModel, _sortModel);
        }

        // GET: api/VehicleModel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IVehicleModelServiceModel>> GetVehicleModelServiceModel(int id)
        {
            var vehicleModelServiceModel = await _vehicleService.GetAsync<IVehicleModelServiceModel>(id);

            if (vehicleModelServiceModel == null)
            {
                return NotFound();
            }

            return Ok(vehicleModelServiceModel);
        }

        // PUT: api/VehicleModel/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleModelServiceModel(int id, IVehicleModelServiceModel vehicleModelServiceModel)
        {
            if (id != vehicleModelServiceModel.Id)
            {
                return BadRequest();
            }

            await _vehicleService.UpdateAsync(vehicleModelServiceModel);

            return NoContent();
        }

        // POST: api/VehicleModel
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IVehicleModelServiceModel>> PostVehicleModelServiceModel(IVehicleModelServiceModel vehicleModelServiceModel)
        {
            await _vehicleService.CreateAsync(vehicleModelServiceModel);

            return CreatedAtAction("GetVehicleModelServiceModel", new { id = vehicleModelServiceModel.Id }, vehicleModelServiceModel);
        }

        // DELETE: api/VehicleModel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IVehicleModelServiceModel>> DeleteVehicleModelServiceModel(int id)
        {
            var vehicleModelServiceModel = await _vehicleService.GetAsync<IVehicleModelServiceModel>(id);
            if (vehicleModelServiceModel == null)
            {
                return NotFound();
            }

            await _vehicleService.DeleteAsync<IVehicleModelServiceModel>(id);

            return Ok(vehicleModelServiceModel);
        }
    }
}
