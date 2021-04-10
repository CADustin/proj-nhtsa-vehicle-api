// <copyright file="GetAllVehicleMakes.cs" company="Dustin Ellis">
//     Copyright (c) Dustin Ellis. All rights reserved.
// </copyright>

namespace NHTSAVehicleAPI.Schema
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// The response class for the NHTSA AllVehicleMakes function.
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "Response")]
    public class GetAllVehicleMakes : ResponseBase
    {
        /// <summary>
        /// Gets or sets a list of all vehicle makes.
        /// </summary>
        [DataMember]
        [XmlArray("Results")]
        [XmlArrayItem("AllVehicleMakes")]
        public List<Make> AllVehicleMakes { get; set; }
    }
}