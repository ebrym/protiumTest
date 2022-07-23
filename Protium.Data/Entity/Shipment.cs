using Protium.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Protium.Data.Entity
{
   public class Shipment : BaseEntity.Entity
	{
        public string? Origin { get; set; }
		public string? Destination { get; set; }
		public ShipmentStatus Status { get; set; }
		public string? ShipmentDate { get; set; }
		public string? DriverId { get; set; }
		public virtual Driver? Driver { get; set; }
		public string? PlannedDate { get; set; }
		public DateTimeOffset EffectiveDate { get; set; }
		public string? Comments { get; set; }
	}
}
