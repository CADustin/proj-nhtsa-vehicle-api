// <copyright file="GetModelsForMake.cs" company="Dustin Ellis">
//     Copyright (c) Dustin Ellis. All rights reserved.
// </copyright>

namespace NHTSAVehicleAPI.Schema
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// The response class for the NHTSA ModelsForMake function
    /// </summary>
    [XmlRoot(ElementName = "Response")]
    public class GetModelsForMake : ResponseBase
    {
        /// <summary>
        /// Gets or sets a list of models
        /// </summary>
        [XmlArray("Results"), XmlArrayItem("ModelsForMake")]
        public List<Model> ModelsForMake { get; set; }
    }
}
