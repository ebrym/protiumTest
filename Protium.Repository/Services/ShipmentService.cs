﻿using AutoMapper;
using Protium.Data.Common;
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
    public class shipmentService : IShipmentService
    {
        private IRepository<Shipment> shipmentRepository;
        private IRepository<Driver> driverRepository;
        private readonly IMapper mapper;

        public shipmentService(IRepository<Shipment> shipmentRepository,
                                IRepository<Driver> driverRepository,
                                     IMapper mapper)
        {
            this.shipmentRepository = shipmentRepository;
            this.driverRepository = driverRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ShipmentDto>> GetShipments()
        {
            var result = await shipmentRepository.GetAll();
            var shipments = mapper.Map<List<ShipmentDto>>(result);
            return shipments;
        }

        public async Task<(bool Succeed, string Message, ShipmentDto)> GetShipment(string id)
        {
            var result = await shipmentRepository.Get(id);
            if (result == null) return (false, "Shipment Not found", null);
            var shipment = mapper.Map<ShipmentDto>(result);
            return (true, "Success", shipment);
        }

        public async Task<(bool Succeed, string Message, ShipmentDto)> InsertShipment(ShipmentDto ShipmentDto)
        {
            ShipmentDto.Id = Guid.NewGuid().ToString();
            var shipment = mapper.Map<Shipment>(ShipmentDto);

            // check if driver exist
            var driver = await driverRepository.Get(ShipmentDto.DriverId);
            if (driver == null) return (false, "Driver does not exist", null);

            shipment.Driver = driver;
            var result = await shipmentRepository.Insert(shipment);

            if (result == null) return (false, "Could not add shipment", null);
            return (true, "shipment Added", mapper.Map<ShipmentDto>(result));
        }

        public async Task<(bool Succeed, string Message, ShipmentDto)> UpdateShipment(ShipmentDto shipmentUpdate)
        {
            //

            var shipment = await shipmentRepository.Get(shipmentUpdate.Id);

            if (shipment == null) return (false, "Shipment not found", null);

            // check if driver exist
            var driver = await driverRepository.Get(shipmentUpdate.DriverId);
            if (driver == null) return (false, "Driver does not exist", null);

            shipment.Driver = driver;
            shipment.Origin = shipmentUpdate.Origin;
            shipment.Destination = shipmentUpdate.Destination;
            shipment.PlannedDate = shipmentUpdate.PlannedDate;
            shipment.Comments = shipmentUpdate.Comments;
            shipment.DriverId = shipmentUpdate.DriverId;
            shipment.Status = shipmentUpdate.Status;
            shipment.ShipmentDate = shipmentUpdate.ShipmentDate;
            shipment.EffectiveDate = shipmentUpdate.EffectiveDate;

            var result = await shipmentRepository.Update(shipment);

            if (result == null) return (false, "Shipment not updated", null);
            var shipmentMap = mapper.Map<ShipmentDto>(shipment);

            return (true, "shipment Updated", shipmentMap);
        }

        public async Task<(bool Succeed, string Message)> DeleteShipment(string id)
        {
            var shipment = await shipmentRepository.Get(id);
            if (shipment == null) return (false, "Shipment does not exist!");

            shipmentRepository.Delete(shipment);
            return (true, "success");
        }

        public async Task<(bool Succeed, string Message, ShipmentDto)> UpdateShipmentStatus(ShipmentStatus Status, string id)
        {
            //

            var shipment = await shipmentRepository.Get(id);

            if (shipment == null) return (false, "Shipment not found", null);

            shipment.Status = Status;

            var result = await shipmentRepository.Update(shipment);

            if (result == null) return (false, "Shipment not updated", null);
            var shipmentMap = mapper.Map<ShipmentDto>(shipment);

            return (true, "Shipment Updated", shipmentMap);
        }
    }
}
