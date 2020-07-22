// <copyright file="GetAllVehicleMakes.cs" company="Dustin Ellis">
//     Copyright (c) Dustin Ellis. All rights reserved.
// </copyright>

namespace NHTSAVehicleAPI.Schema
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// The response class for the NHTSA AllVehicleMakes function
    /// </summary>
    [XmlRoot(ElementName = "Response")]
    public class GetAllVehicleMakes : ResponseBase
    {
        /// <summary>
        /// Gets or sets a list of all vehicle makes
        /// </summary>
        [XmlArray("Results"), XmlArrayItem("AllVehicleMakes")]
        public List<Make> AllVehicleMakes { get; set; }
    }
}
