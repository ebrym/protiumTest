using Microsoft.AspNetCore.Mvc;
using Protium.Api.Models;
using Protium.Repository.Dto;
using Protium.Repository.Interface;

namespace Protium.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : BaseController
    {
      

        private readonly ILogger<DriverController> _logger;
        private readonly IDriverService _driverService;

        public DriverController(ILogger<DriverController> logger, IDriverService driverService)
        {
            _logger = logger;
            _driverService = driverService;
        }


        #region Query
        /// <summary>
        /// Gets all drivers.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesDefaultResponseType(typeof(List<DriverModel>))]
        public async Task<IActionResult> GetAll()
        {
            var result = await _driverService.GetDrivers();

            return Ok(result.ToResponse());

        }
        #endregion


        #region Command
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesDefaultResponseType(typeof(DriverModel))]
        public async Task<IActionResult> CreateNonClass([FromBody] DriverDto driver)
        {

            var result = await _driverService.InsertDriver(driver);

            return Ok(result.ToResponse());
        }

        #endregion
    }
}