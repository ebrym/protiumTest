using Protium.Data.Entity;
using Protium.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protium.Repository.Interface
{
    public interface IDriverService: IDependencyRegister
    {
        Task<IEnumerable<DriverDto>> GetDrivers();
        Task<DriverDto> GetDriver(string id);
        Task<DriverDto> InsertDriver(DriverDto driver);
        Task<DriverDto> UpdateDriver(DriverDto driver);
        void DeleteDriver(Driver driver);
    }
}
