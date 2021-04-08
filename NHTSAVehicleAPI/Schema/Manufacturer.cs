// <copyright file="Manufacturer.cs" company="Dustin Ellis">
//     Copyright (c) Dustin Ellis. All rights reserved.
// </copyright>

namespace NHTSAVehicleAPI.Schema
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// Manufacturer class
    /// </summary>
    [DataContract]
    public class Manufacturer
    {
        /// <summary>
        /// Gets or sets the First Line of the Address
        /// </summary>
        [DataMember]
        [XmlElement("Address")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the Second Line of the Address
        /// </summary>
        [DataMember]
        [XmlElement("Address2")]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the City
        /// </summary>
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the DBA (Doing Business As) name for the Vehicle Manufacturer
        /// </summary>
        [DataMember]
        [XmlElement("Mfr_CommonName")]
        public string CommonName { get; set; }

        /// <summary>
        /// Gets or sets the Contact Email
        /// </summary>
        [DataMember]
        public string ContactEmail { get; set; }

        /// <summary>
        /// Gets or sets the Contact Phone number
        /// </summary>
        [DataMember]
        public string ContactPhone { get; set; }

        /// <summary>
        /// Gets or sets the Country
        /// </summary>
        [DataMember]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets equipment items
        /// </summary>
        /// <remarks>
        /// It's not clear to me what this looks like because I cannot find an actual example of how
        /// or where it is used.
        /// </remarks>
        [DataMember]
        public List<object> EquipmentItems { get; set; }

        /// <summary>
        /// Gets or sets the NHTSA ID for the Vehicle Manufacturer
        /// </summary>
        [DataMember]
        [XmlElement("Mfr_ID")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the timestamp for the last time the record was updated by the NHTSA
        /// </summary>
        [DataMember]
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets a list of Manufacturer types
        /// </summary>
        [DataMember]
        public List<ManufacturerType> ManufacturerTypes { get; set; }

        /// <summary>
        /// Gets or sets the Manufacturer Name
        /// </summary>
        [DataMember]
        [XmlElement("Mfr_Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Other Manufacturer Details
        /// </summary>
        [DataMember]
        public string OtherManufacturerDetails { get; set; }

        /// <summary>
        /// Gets or sets the Postal Code
        /// </summary>
        [DataMember]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the Principal contact's First Name
        /// </summary>
        [DataMember]
        public string PrincipalFirstName { get; set; }

        /// <summary>
        /// Gets or sets the Principal contact's Last Name
        /// </summary>
        [DataMember]
        public string PrincipalLastName { get; set; }

        /// <summary>
        /// Gets or sets the Principle contact's Position/Title
        /// </summary>
        [DataMember]
        public string PrincipalPosition { get; set; }

        /// <summary>
        /// Gets or sets the State (or Province)
        /// </summary>
        [DataMember]
        public string StateProvince { get; set; }

        /// <summary>
        /// Gets or sets the name of the person who submitted the record
        /// </summary>
        [DataMember]
        public string SubmittedName { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of when the record was submitted
        /// </summary>
        [DataMember]
        public DateTime? SubmittedOn { get; set; }

        /// <summary>
        /// Gets or sets the position of the person who submitted the record
        /// </summary>
        [DataMember]
        public string SubmittedPosition { get; set; }

        /// <summary>
        /// Gets or sets a list of Vehicle Types
        /// </summary>
        [DataMember]
        public List<VehicleType> VehicleTypes { get; set; }
    }
}