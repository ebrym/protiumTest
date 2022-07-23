using AutoMapper;
using Protium.Data.Entity;
using Protium.Repository.Dto;
using Protium.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protium.Repository.Services
{
    public class DriverService : IDriverService
    {
        private IRepository<Driver> driverRepository; 
        private readonly IMapper mapper;

        public DriverService(IRepository<Driver> driverRepository,
                                     IMapper mapper)
        {
            this.driverRepository = driverRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<DriverDto>> GetDrivers()
        {
            var result = await driverRepository.GetAll();
            var drivers = mapper.Map<List<DriverDto>>(result);
            return drivers;
        }

        public async Task<DriverDto> GetDriver(string id)
        {
            var result = await driverRepository.Get(id);
            var driver = mapper.Map<DriverDto>(result);
            return driver;
        }

        public async Task<DriverDto> InsertDriver(DriverDto driverdto)
        {
            var driver = mapper.Map<Driver>(driverdto);

           var result =  await driverRepository.Insert(driver);
            return mapper.Map<DriverDto>(result);
        }

        public async Task<DriverDto> UpdateDriver(DriverDto driver)
        {
            var driverMap = mapper.Map<Driver>(driver);
            await driverRepository.Update(driverMap);
            return driver;
        }

        public void DeleteDriver(Driver driver)
        {
            driverRepository.Delete(driver);
        }
    }
}
