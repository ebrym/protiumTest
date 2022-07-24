using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using Protium.Api.Models.Response;
using Protium.Data.Common;

namespace Protium.Api.Models.Request
{
    public class ShipmentStatusUpdateRequestModel 
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string? Id { get; set; }
        /// <summary>
        /// Gets or sets the Shipment Status.
        /// </summary>
        /// <value>
        /// The Shipment Status.
        /// </value>
        [Required]
        [JsonPropertyName("status")]
        public ShipmentStatus Status { get; set; }

    }
}

