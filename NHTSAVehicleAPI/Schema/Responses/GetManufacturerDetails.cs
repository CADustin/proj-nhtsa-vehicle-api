// <copyright file="GetManufacturerDetails.cs" company="Dustin Ellis">
//     Copyright (c) Dustin Ellis. All rights reserved.
// </copyright>

namespace NHTSAVehicleAPI.Schema
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// The response class for the NHTSA ManufacturerDetails function
    /// </summary>
    /// <remarks>
    /// Notice that the <c>NHTSA</c> has a spelling mistake with the <c>Reponse</c> element. On the
    /// other's I have worked with so far, it was spelt, "Response".
    /// </remarks>
    [DataContract]
    [XmlRoot(ElementName = "Reponse")]
    public class GetManufacturerDetails : ResponseBase
    {
        /// <summary>
        /// Gets or sets a list of Manufacturers
        /// </summary>
        [DataMember]
        [XmlArray("Results"), XmlArrayItem("ManufacturerDetails")]
        public List<Manufacturer> ManufacturerDetails { get; set; }
    }
}