// <copyright file="ReadAPI.cs" company="Dustin Ellis">
//     Copyright (c) Dustin Ellis. All rights reserved.
// </copyright>

namespace NHTSAVehicleAPI
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;

    /// <summary>
    /// Read the <c>NHTSA</c><c>API</c>
    /// </summary>
    public class ReadAPI
    {
        /// <summary>
        /// THe format you want back from the <c>API</c>
        /// </summary>
        private const string Format = "format=XML";

        /// <summary>
        /// The URL to the <c>NHTSA</c> Vehicle <c>API</c>
        /// </summary>
        private const string VehicleAPI = @"https://vpic.nhtsa.dot.gov/api/vehicles/";

        /// <summary>
        /// Get All Makes from the NHTSA <seealso cref="https://vpic.nhtsa.dot.gov/api/vehicles/getallmakes?format=XML"/>
        /// </summary>
        /// <returns><see cref="Schema.AllVehicleMakes.GetAllVehicleMakes"/> for the <c>NHTSA</c><c>API</c></returns>
        public Schema.GetAllVehicleMakes GetAllMakes()
        {
            const string Method = "getallmakes";

            string url = string.Join(string.Empty, VehicleAPI, Method, "?" + Format);
            string pathToXML = this.DownloadXML(url);
            return SerializeConfig<Schema.GetAllVehicleMakes>.DeserializeUsingXmlSerializer(pathToXML);
        }

        /// <summary>
        /// Get all manufacturers from the NHTSA <seealso cref="https://vpic.nhtsa.dot.gov/api/vehicles/getallmanufacturers?format=XML&amp;page=2"/>
        /// </summary>
        /// <returns><see cref="Schema.GetModelsForMake"/> for the <c>NHTSA</c><c>API</c></returns>
        public Schema.GetModelsForMake GetAllManufacturers()
        {
            const string Method = "getallmanufacturers";

            // TODO: Deal with the pages
            // TODO: Update the Return Type
            string url = string.Join(string.Empty, VehicleAPI, Method, "?" + Format);
            string pathToXML = this.DownloadXML(url);
            return SerializeConfig<Schema.GetModelsForMake>.DeserializeUsingXmlSerializer(pathToXML);
        }

        /// <summary>
        /// Get the manufacturer details for some make from the NHTSA <seealso cref="https://vpic.nhtsa.dot.gov/api/vehicles/getmanufacturerdetails/honda?format=XML"/>
        /// </summary>
        /// <param name="make">The Make that you want details for</param>
        /// <returns><see cref="Schema.ModelsForMake.Response"/> for the <c>NHTSA</c><c>API</c></returns>
        public Schema.GetModelsForMake GetManufacturerDetails(string make)
        {
            const string Method = "getmanufacturerdetails";

            if (string.IsNullOrWhiteSpace(make))
            {
                throw new ArgumentException("The parameter for the make cannot be an empty string.", nameof(make));
            }

            // TODO: Update the Return Type
            string url = string.Join(string.Empty, VehicleAPI, Method, "/" + make, "?" + Format);
            string pathToXML = this.DownloadXML(url);
            return SerializeConfig<Schema.GetModelsForMake>.DeserializeUsingXmlSerializer(pathToXML);
        }

        /// <summary>
        /// Get Models for a Make and Year from the NHTSA <seealso cref="https://vpic.nhtsa.dot.gov/api/vehicles/getmodelsformakeyear/make/honda/modelyear/2015?format=xml"/>
        /// </summary>
        /// <param name="make">The Make that you want models for</param>
        /// <param name="year">The year of models</param>
        /// <returns><see cref="Schema.ModelsForMakeYear.Response"/> for the <c>NHTSA</c><c>API</c></returns>
        public Schema.GetMakeModels GetModels(string make, int year)
        {
            const string Method = "getmodelsformakeyear";

            const int MinimumYear = 1879;
            int nextYear = DateTime.Now.Year + 1;
            if (string.IsNullOrWhiteSpace(make))
            {
                throw new ArgumentException("The parameter for the make cannot be an empty string.", nameof(make));
            }
            else if (year < MinimumYear || year > nextYear)
            {
                throw new ArgumentException(string.Format("The parameter for the year must be between {0} and {1}.", MinimumYear, nextYear), nameof(year));
            }

            string url = string.Join(string.Empty, VehicleAPI, Method, "/make/" + make, "/modelyear/" + year, "?" + Format);
            string pathToXML = this.DownloadXML(url);
            return SerializeConfig<Schema.GetMakeModels>.DeserializeUsingXmlSerializer(pathToXML);
        }

        /// <summary>
        /// Get Models for a Make and Year from the NHTSA <seealso cref="https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeId/440?format=xml"/>
        /// </summary>
        /// <param name="makeId">The Make ID that you want Models for</param>
        /// <returns><see cref="Schema.ModelsForMakeId.Response"/> for the <c>NHTSA</c><c>API</c></returns>
        public Schema.GetModelsForMake GetModels(int makeId)
        {
            const string Method = "GetModelsForMakeId";

            if (makeId < 0)
            {
                throw new ArgumentException("The parameter for the makeId must be greather than 0.", nameof(makeId));
            }

            string url = string.Join(string.Empty, VehicleAPI, Method, "/" + makeId, "?" + Format);
            string pathToXML = this.DownloadXML(url);
            return SerializeConfig<Schema.GetModelsForMake>.DeserializeUsingXmlSerializer(pathToXML);
        }

        /// <summary>
        /// Get Models for a Make and Year from the NHTSA <seealso cref="https://vpic.nhtsa.dot.gov/api/vehicles/getmodelsformake/honda?format=xml"/>
        /// </summary>
        /// <param name="make">The Make that you want models for</param>
        /// <returns><see cref="Schema.ModelsForMake.Response"/> for the <c>NHTSA</c><c>API</c></returns>
        public Schema.GetModelsForMake GetModels(string make)
        {
            const string Method = "getmodelsformake";

            if (string.IsNullOrWhiteSpace(make))
            {
                throw new ArgumentException("The parameter for the make cannot be an empty string.", nameof(make));
            }

            string url = string.Join(string.Empty, VehicleAPI, Method, "/" + make, "?" + Format);
            string pathToXML = this.DownloadXML(url);
            return SerializeConfig<Schema.GetModelsForMake>.DeserializeUsingXmlSerializer(pathToXML);
        }

        /// <summary>
        /// Downloads the XML at some HTTP Address to a temporary file
        /// </summary>
        /// <param name="address">The address to where the XML can be downloaded</param>
        /// <returns>Path to a temp file containing the XML</returns>
        private string DownloadXML(string address)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string toFile = Path.GetTempFileName();
            using (var wc = new WebClient())
            {
                Debug.WriteLine(string.Format("Downloading address: {0}", address));
                string xml = wc.DownloadString(address);

                Debug.WriteLine(string.Format("Saving to file: {0}", toFile));
                File.WriteAllText(toFile, xml);
                sw.Stop();
            }

            Debug.WriteLine(string.Format("Execution of DownloadXML(string) took {0}ms", sw.ElapsedMilliseconds));

            return toFile;
        }
    }
}