using Protium.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Protium.Web.Models
{
    public class ShipmentViewModel : ShipmentModel
    {
        /// <summary>
        /// Gets or sets the Shipment Status.
        /// </summary>
        /// <value>
        /// The Shipment Status.
        /// </value>
        [Required]
        public ShipmentStatus Status { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        public DateTime? UpdatedAt { get; set; }
        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public DateTime? UpdatedBy { get; set; }
    }

   
}
