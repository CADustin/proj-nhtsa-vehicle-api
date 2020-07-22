// <copyright file="Make.cs" company="Dustin Ellis">
//     Copyright (c) Dustin Ellis. All rights reserved.
// </copyright>

namespace NHTSAVehicleAPI.Schema
{
    using System.Data;
    using System.Xml.Serialization;

    /// <summary>
    /// Vehicle Make
    /// </summary>
    public class Make
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Make"/> class.
        /// </summary>
        public Make()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Make"/> class.
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> which contains data to be stored inside of <see cref="Make"/></param>
        public Make(DataRow dataRow)
        {
            int idIndex = dataRow.Table.Columns.IndexOf("MakeID");
            int tempMakeID = 0;
            if (idIndex >= 0)
            {
                int.TryParse(dataRow.ItemArray[idIndex].ToString(), out tempMakeID);
            }

            // If the TryParse fails we will get 0, which is the default we want
            this.MakeID = tempMakeID;

            int nameIndex = dataRow.Table.Columns.IndexOf("MakeName");
            if (nameIndex >= 0)
            {
                this.MakeName = dataRow.ItemArray[nameIndex].ToString();
            }
            else
            {
                this.MakeName = string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the NHTSA ID for the Make
        /// </summary>
        [XmlElement("Make_ID")]
        public int MakeID { get; set; }

        /// <summary>
        /// Gets or sets the Name of the Make
        /// </summary>
        [XmlElement("Make_Name")]
        public string MakeName { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return MakeName;
        }
    }
}
