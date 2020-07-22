// <copyright file="VehicleType.cs" company="Dustin Ellis">
//     Copyright (c) Dustin Ellis. All rights reserved.
// </copyright>

namespace NHTSAVehicleAPI.Schema
{
    /// <summary>
    /// Vehicle Type class
    /// </summary>
    public class VehicleType
    {
        /// <summary>
        /// Gets or sets the Name of the Vehicle Type
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not this is the Manufacturer's primary vehicle type or not
        /// </summary>
        public bool IsPrimary { get; set; }

        /// <summary>
        /// Gets or sets the Gross vehicle weight rating (From)
        /// </summary>
        /// <remarks>
        /// It's not totally clear to me what this is for exactly -- but for now I want to be able to deserialize it.
        /// </remarks>
        public string GVWRFrom { get; set; }

        /// <summary>
        /// Gets or sets the Gross vehicle weight rating (From)
        /// </summary>
        /// <remarks>
        /// It's not totally clear to me what this is for exactly -- but for now I want to be able to deserialize it.
        /// </remarks>
        public string GVWRTo { get; set; }
    }
}
