// <copyright file="Manufacturer.cs" company="Dustin Ellis">
//     Copyright (c) Dustin Ellis. All rights reserved.
// </copyright>

namespace NHTSAVehicleAPI.Schema
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// Manufacturer class
    /// </summary>
    public class Manufacturer
    {
        /// <summary>
        /// Gets or sets the NHTSA ID for the Vehicle Manufacturer
        /// </summary>
        [XmlElement("Mfr_ID")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Manufacturer Name
        /// </summary>
        [XmlElement("Mfr_Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the DBA (Doing Business As) name for the Vehicle Manufacturer
        /// </summary>
        [XmlElement("Mfr_CommonName")]
        public string CommonName { get; set; }

        /// <summary>
        /// Gets or sets the First Line of the Address
        /// </summary>
        [XmlElement("Address")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the Second Line of the Address
        /// </summary>
        [XmlElement("Address2")]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the State (or Province)
        /// </summary>
        public string StateProvince { get; set; }

        /// <summary>
        /// Gets or sets the Postal Code
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the timestamp for the last time the record was updated by the NHTSA
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets Other Manufacturer Details
        /// </summary>
        public string OtherManufacturerDetails { get; set; }

        /// <summary>
        /// Gets or sets the Principal contact's First Name
        /// </summary>
        public string PrincipalFirstName { get; set; }

        /// <summary>
        /// Gets or sets the Principal contact's Last Name
        /// </summary>
        public string PrincipalLastName { get; set; }

        /// <summary>
        /// Gets or sets the Principle contact's Position/Title
        /// </summary>
        public string PrincipalPosition { get; set; }

        /// <summary>
        /// Gets or sets the Contact Phone number
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// Gets or sets the Contact Email
        /// </summary>
        public string ContactEmail { get; set; }

        /// <summary>
        /// Gets or sets the name of the person who submitted the record
        /// </summary>
        public string SubmittedName { get; set; }

        /// <summary>
        /// Gets or sets the position of the person who submitted the record
        /// </summary>
        public string SubmittedPosition { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of when the record was submitted
        /// </summary>
        public DateTime? SubmittedOn { get; set; }

        /// <summary>
        /// Gets or sets equipment items
        /// </summary>
        /// <remarks>
        /// It's not clear to me what this looks like because I cannot find an actual example of how or where it is used.
        /// </remarks>
        public List<object> EquipmentItems { get; set; }

        /// <summary>
        /// Gets or sets a list of Vehicle Types
        /// </summary>
        public List<VehicleType> VehicleTypes { get; set; }

        /// <summary>
        /// Gets or sets a list of Manufacturer types
        /// </summary>
        public List<ManufacturerType> ManufacturerTypes { get; set; }
    }
}
