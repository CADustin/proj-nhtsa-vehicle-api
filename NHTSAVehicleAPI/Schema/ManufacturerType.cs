// <copyright file="ManufacturerType.cs" company="Dustin Ellis">
//     Copyright (c) Dustin Ellis. All rights reserved.
// </copyright>

namespace NHTSAVehicleAPI.Schema
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Manufacturer Type class
    /// </summary>
    [DataContract]
    public class ManufacturerType
    {
        /// <summary>
        /// Gets or sets the Name of the Manufacturer Type
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}