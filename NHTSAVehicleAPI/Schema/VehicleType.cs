// <copyright file="VehicleType.cs" company="Dustin Ellis">
//     Copyright (c) Dustin Ellis. All rights reserved.
// </copyright>

namespace NHTSAVehicleAPI.Schema
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Vehicle Type class
    /// </summary>
    [DataContract]
    public class VehicleType
    {
        /// <summary>
        /// Gets or sets the Gross vehicle weight rating (From)
        /// </summary>
        /// <remarks>
        /// It's not totally clear to me what this is for exactly -- but for now I want to be able
        /// to deserialize it.
        /// </remarks>
        [DataMember]
        public string GVWRFrom { get; set; }

        /// <summary>
        /// Gets or sets the Gross vehicle weight rating (From)
        /// </summary>
        /// <remarks>
        /// It's not totally clear to me what this is for exactly -- but for now I want to be able
        /// to deserialize it.
        /// </remarks>
        [DataMember]
        public string GVWRTo { get; set; }

        [DataMember]
        public bool IsPrimary { get; set; }

        /// <summary>
        /// Gets or sets the Name of the Vehicle Type
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}