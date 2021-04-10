// <copyright file="Model.cs" company="Dustin Ellis">
//     Copyright (c) Dustin Ellis. All rights reserved.
// </copyright>

namespace NHTSAVehicleAPI.Schema
{
    using System.Data;
    using System.Diagnostics;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// Vehicle Model.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("{this.ModelName}")]
    public class Model : Make
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Model"/> class.
        /// </summary>
        public Model()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Model"/> class.
        /// </summary>
        /// <param name="dataRow">
        /// <see cref="DataRow"/> which contains data to be stored inside of <see cref="Model"/>.
        /// </param>
        public Model(DataRow dataRow)
            : base(dataRow)
        {
            int idIndex = dataRow.Table.Columns.IndexOf("ModelID");
            int tempModelID = 0;
            if (idIndex >= 0)
            {
                _ = int.TryParse(dataRow.ItemArray[idIndex].ToString(), out tempModelID);
            }

            // If the TryParse fails we will get 0, which is the default we want
            this.ModelID = tempModelID;

            int nameIndex = dataRow.Table.Columns.IndexOf("ModelName");
            if (nameIndex >= 0)
            {
                this.ModelName = dataRow.ItemArray[nameIndex].ToString();
            }
            else
            {
                this.ModelName = string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the NHTSA ID for the Model.
        /// </summary>
        [DataMember]
        [XmlElement("Model_ID")]
        public int ModelID { get; set; }

        /// <summary>
        /// Gets or sets the Model Name.
        /// </summary>
        [DataMember]
        [XmlElement("Model_Name")]
        public string ModelName { get; set; }
    }
}