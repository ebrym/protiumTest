using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Protium.Api.Models;
using Protium.Api.Models.Request;
using Protium.Api.Models.Response;
using Protium.Repository.Dto;
using Protium.Repository.Interface;

namespace Protium.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class DriverController : BaseController
    {
      

        private readonly ILogger<DriverController> _logger;
        private readonly IDriverService _driverService;
        private readonly IMapper _mapper;

        public DriverController(ILogger<DriverController> logger, IDriverService driverService,
        IMapper mapper)
        {
            _logger = logger;
            _driverService = driverService;
            _mapper = mapper;
        }


        #region Query
        /// <summary>
        /// Gets all drivers.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesDefaultResponseType(typeof(List<DriverResponseModel>))]
        public async Task<IActionResult> GetAll()
        {
            var result = await _driverService.GetDrivers();
            var driver = _mapper.Map<List<DriverResponseModel>>(result);

            return Ok(driver.ToResponse());

        }

        /// <summary>
        /// Gets a specifc driver
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesDefaultResponseType(typeof(DriverResponseModel))]
        public async Task<IActionResult> GetById(string id)
        {
            
                var result = await _driverService.GetDriver(id);
                if (result.Succeed)
                return Ok(_mapper.Map<DriverResponseModel>(result.Item3).ToResponse());
            return NotFound(result.ToResponse(false,result.Message));
           
            
        }


        #endregion


        #region Command
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesDefaultResponseType(typeof(DriverResponseModel))]
        public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequestModel driverRequstModel)
        {
            var driver = _mapper.Map<DriverDto>(driverRequstModel);
            var result = await _driverService.InsertDriver(driver);
            if(result.Succeed)
                return Ok(_mapper.Map<DriverResponseModel>(result.Item3).ToResponse());

            return NotFound(result.ToResponse(false, result.Message));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesDefaultResponseType(typeof(DriverResponseModel))]
        public async Task<IActionResult> Update([FromBody] DriverRequestModel driverRequstModel)
        {
            var driver = _mapper.Map<DriverDto>(driverRequstModel);
            var result = await _driverService.UpdateDriver(driver);
            if (result.Succeed)
                return Ok(_mapper.Map<DriverResponseModel>(result.Item3).ToResponse());

            return NotFound(result.ToResponse(false, result.Message));
        }


        /// <summary>
        /// Deletes a new Country
        /// </summary>
        /// <param name="countryRequest"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _driverService.DeleteDriver(id);
            if(result.Succeed)
                return Ok(result.ToResponse());
            return BadRequest(result.ToResponse(false, result.Message));
        }
        #endregion
    }
}