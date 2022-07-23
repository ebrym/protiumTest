using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protium.Data.Common
{
   public enum ShipmentStatus
    {
        /// <summary>
        /// The initial
        /// </summary>
        Init,
        /// <summary>
        /// The pickup
        /// </summary>
        PickUp,
        /// <summary>
        /// The shipment is delivered
        /// </summary>
        Delivered,
            /// <summary>
            /// The shipment was returned
            /// </summary>
        Returned

    }
}
