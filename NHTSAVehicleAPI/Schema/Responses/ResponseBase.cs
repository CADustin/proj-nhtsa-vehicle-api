// <copyright file="ResponseBase.cs" company="Dustin Ellis">
//     Copyright (c) Dustin Ellis. All rights reserved.
// </copyright>

namespace NHTSAVehicleAPI.Schema
{
    /// <summary>
    /// Response Base class
    /// </summary>
    public class ResponseBase
    {
        /// <summary>
        /// Gets or sets the count of results
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the search criteria used
        /// </summary>
        public string SearchCriteria { get; set; }
    }
}
