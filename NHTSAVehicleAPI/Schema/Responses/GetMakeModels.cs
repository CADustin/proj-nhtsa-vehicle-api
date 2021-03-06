﻿// <copyright file="GetMakeModels.cs" company="Dustin Ellis">
//     Copyright (c) Dustin Ellis. All rights reserved.
// </copyright>

namespace NHTSAVehicleAPI.Schema
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// The response class for the NHTSA ModelsForMakeIdYear function.
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "Response")]
    public class GetMakeModels : ResponseBase
    {
        /// <summary>
        /// Gets or sets a list of models.
        /// </summary>
        [DataMember]
        [XmlArray("Results")]
        [XmlArrayItem("MakeModels")]
        public List<Model> MakeModels { get; set; }
    }
}