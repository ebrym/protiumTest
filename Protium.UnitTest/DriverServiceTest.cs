using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Xunit;
using Protium.Repository.Interface;
using Moq;
using Protium.Data.Entity;
using Protium.Data;
using Microsoft.EntityFrameworkCore;
using Protium.UnitTest.Models;
using Protium.Repository.Repository;
using Protium.Repository.Dto;

namespace Protium.UnitTest
{
    public class DriverServiceTest
    {
        

        [Fact]
        public async Task Create_Driver_Calls_DriverService_Insert()
        {
            var testObject = new DriverDto
            {
                FirstName = "Ade",
                LastName = "Dele",
                VehiclePlate = "pls123ok",
            };

            var mockDriverService = new Mock<IDriverService>();
            mockDriverService.Setup(x => x.InsertDriver(testObject));
            await mockDriverService.Object.InsertDriver(testObject);
            mockDriverService.Verify(x => x.InsertDriver(testObject), Times.Once());
        }

   
    }
}
