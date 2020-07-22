// <copyright file="UnitTest1.cs" company="Dustin Ellis">
//     Copyright (c) Dustin Ellis. All rights reserved.
// </copyright>

namespace NHTSAVehicleAPITest
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NHTSAVehicleAPI;
    using NHTSAVehicleAPI.Schema;

    /// <summary>
    /// Test class
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test a deserialization and then serialization to be sure we create the same file that the NHTSA creates
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Validate), TestCategory(TestGroups.Serialization)]
        [DeploymentItem(@"Data\GetAllMakes.xml")]
        public void TestDeserializeThenSerializeRealData_GetAllMakes()
        {
            const string RealDataFile = @"Data\GetAllMakes.xml";

            var deserializedResults = SerializeConfig<NHTSAVehicleAPI.Schema.GetAllVehicleMakes>.DeSerialize(RealDataFile);
            Assert.AreEqual(8716, deserializedResults.AllVehicleMakes.Count);
            Assert.AreEqual(deserializedResults.Count, deserializedResults.AllVehicleMakes.Count);
            Assert.IsTrue(deserializedResults.AllVehicleMakes.Any(x => x.MakeName == "Tesla"));
            Assert.IsTrue(deserializedResults.AllVehicleMakes.Any(x => x.MakeName == "Honda"));

            // Reserialize the data, but to a temp file
            string tempFile = System.IO.Path.GetTempFileName();
            SerializeConfig<NHTSAVehicleAPI.Schema.GetAllVehicleMakes>.Serialize(tempFile, deserializedResults);

            UnitTest1.CompareFiles(tempFile, RealDataFile);
        }

        /// <summary>
        /// Test a deserialization and then serialization to be sure we create the same file that the NHTSA creates
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Validate), TestCategory(TestGroups.Serialization)]
        [DeploymentItem(@"Data\GetManufacturerDetails_Honda.xml")]
        public void TestDeserializeThenSerializeRealData_GetManufacturerDetails_Honda()
        {
            const string RealDataFile = @"Data\GetManufacturerDetails_Honda.xml";

            var deserializedResults = SerializeConfig<NHTSAVehicleAPI.Schema.GetManufacturerDetails>.DeSerialize(RealDataFile);
            Assert.AreEqual(13, deserializedResults.ManufacturerDetails.Count);

            // Reserialize the data, but to a temp file
            string tempFile = System.IO.Path.GetTempFileName();
            SerializeConfig<NHTSAVehicleAPI.Schema.GetManufacturerDetails>.Serialize(tempFile, deserializedResults);

            UnitTest1.CompareFiles(tempFile, RealDataFile);
        }

        /// <summary>
        /// Test a deserialization and then serialization to be sure we create the same file that the NHTSA creates
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Validate), TestCategory(TestGroups.Serialization)]
        [DeploymentItem(@"Data\GetModelsForMake_Honda.xml")]
        public void TestDeserializeThenSerializeRealData_GetModelesForMake_Honda()
        {
            const string RealDataFile = @"Data\GetModelsForMake_Honda.xml";

            var deserializedResults = SerializeConfig<NHTSAVehicleAPI.Schema.GetModelsForMake>.DeSerialize(RealDataFile);
            Assert.AreEqual(810, deserializedResults.ModelsForMake.Count);

            // Reserialize the data, but to a temp file
            string tempFile = System.IO.Path.GetTempFileName();
            SerializeConfig<NHTSAVehicleAPI.Schema.GetModelsForMake>.Serialize(tempFile, deserializedResults);

            UnitTest1.CompareFiles(tempFile, RealDataFile);
        }

        /// <summary>
        /// Test a deserialization and then serialization to be sure we create the same file that the NHTSA creates
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Validate), TestCategory(TestGroups.Serialization)]
        [DeploymentItem(@"Data\GetModelsForMakeId_440.xml")]
        public void TestDeserializeThenSerializeRealData_GetModelsForMakeId_440()
        {
            const string RealDataFile = @"Data\GetModelsForMakeId_440.xml";

            var deserializedResults = SerializeConfig<NHTSAVehicleAPI.Schema.GetModelsForMake>.DeSerialize(RealDataFile);
            Assert.AreEqual(13, deserializedResults.ModelsForMake.Count);

            // Reserialize the data, but to a temp file
            string tempFile = System.IO.Path.GetTempFileName();
            SerializeConfig<NHTSAVehicleAPI.Schema.GetModelsForMake>.Serialize(tempFile, deserializedResults);

            UnitTest1.CompareFiles(tempFile, RealDataFile);
        }

        /// <summary>
        /// Test a deserialization and then serialization to be sure we create the same file that the NHTSA creates
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Validate), TestCategory(TestGroups.Serialization)]
        [DeploymentItem(@"Data\GetModelsForMakeIdYear_474_2015.xml", "Data")]
        public void TestDeserializeThenSerializeRealData_GetModelsForMakeIdYear_474_2015()
        {
            const string RealDataFile = @"Data\GetModelsForMakeIdYear_474_2015.xml";

            var deserializedResults = SerializeConfig<NHTSAVehicleAPI.Schema.GetMakeModels>.DeSerialize(RealDataFile);
            Assert.AreEqual(169, deserializedResults.MakeModels.Count);

            // Reserialize the data, but to a temp file
            string tempFile = System.IO.Path.GetTempFileName();
            SerializeConfig<NHTSAVehicleAPI.Schema.GetMakeModels>.Serialize(tempFile, deserializedResults);

            UnitTest1.CompareFiles(tempFile, RealDataFile);
        }

        /// <summary>
        /// Test a deserialization and then serialization to be sure we create the same file that the NHTSA creates
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Validate), TestCategory(TestGroups.Serialization)]
        [DeploymentItem(@"Data\GetModelsForMakeYear_Honda_2015.xml")]
        public void TestDeserializeThenSerializeRealData_GetModelsForMakeYear_Honda_2015()
        {
            const string RealDataFile = @"Data\GetModelsForMakeYear_Honda_2015.xml";

            var deserializedResults = SerializeConfig<NHTSAVehicleAPI.Schema.GetMakeModels>.DeSerialize(RealDataFile);
            Assert.AreEqual(169, deserializedResults.MakeModels.Count);

            // Reserialize the data, but to a temp file
            string tempFile = System.IO.Path.GetTempFileName();
            SerializeConfig<NHTSAVehicleAPI.Schema.GetMakeModels>.Serialize(tempFile, deserializedResults);

            UnitTest1.CompareFiles(tempFile, RealDataFile);
        }

        /// <summary>
        /// Test <see cref="ReadAPI.GetAllMakes"/> using the live <c>NHTSA</c> servers
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Live)]
        public void TestGetAllMakes()
        {
            var response = new ReadAPI().GetAllMakes();
            Assert.IsTrue(response.Count > 0);
            Assert.IsTrue(response.Message.Contains("successful"));
            Assert.AreEqual(response.Count, response.AllVehicleMakes.Count);
        }

        /// <summary>
        /// Test <see cref="ReadAPI.GetModels(string, int)"/> by passing in an empty manufacturer
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Live), ExpectedException(typeof(ArgumentException))]
        public void TestGetModels_EmptyManufacturer_2013()
        {
            bool caughtException = false;
            const string ExpectedExceptionMessage = "The parameter for the make cannot be an empty string.\r\nParameter name: make";
            try
            {
                var response = new ReadAPI().GetModels(string.Empty, 2013);
            }
            catch (ArgumentException ex)
            {
                caughtException = true;
                Assert.AreEqual(ExpectedExceptionMessage, ex.Message);
                Assert.AreEqual("make", ex.ParamName);
            }

            Assert.IsTrue(caughtException);
        }

        /// <summary>
        /// Test <see cref="ReadAPI.GetModels(string)"/> using the live <c>NHTSA</c> servers
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Live)]
        public void TestGetModels_Ford()
        {
            var response = new ReadAPI().GetModels("ford");
            Assert.IsTrue(response.Count > 0);
            Assert.IsTrue(response.Message.Contains("successful"));
            Assert.AreEqual(response.Count, response.ModelsForMake.Count);
        }

        /// <summary>
        /// Test <see cref="ReadAPI.GetModels(string, int)"/> using the live <c>NHTSA</c> servers
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Live)]
        public void TestGetModels_Ford_2015()
        {
            var response = new ReadAPI().GetModels("ford", 2015);
            Assert.IsTrue(response.Count > 0);
            Assert.IsTrue(response.Message.Contains("successful"));
            Assert.AreEqual(response.Count, response.MakeModels.Count);
        }

        /// <summary>
        /// Test <see cref="ReadAPI.GetModels(string)"/> using the live <c>NHTSA</c> servers
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Live)]
        public void TestGetModels_Honda()
        {
            var response = new ReadAPI().GetModels("honda");
            Assert.IsTrue(response.Count > 0);
            Assert.IsTrue(response.Message.Contains("successful"));
            Assert.AreEqual(response.Count, response.ModelsForMake.Count);
        }

        /// <summary>
        /// Test <see cref="ReadAPI.GetModels(string, int)"/> using the live <c>NHTSA</c> servers
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Live)]
        public void TestGetModels_Honda_2014()
        {
            var response = new ReadAPI().GetModels("honda", 2014);
            Assert.IsTrue(response.Count > 0);
            Assert.IsTrue(response.Message.Contains("successful"));
            Assert.AreEqual(response.Count, response.MakeModels.Count);
        }

        /// <summary>
        /// Test <see cref="ReadAPI.GetModels(string, int)"/> by passing in an 1800 as the year
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Live)]
        public void TestGetModels_Honda_InvalidYear1800()
        {
            bool caughtException = false;

            string expectedExceptionMessage = "The parameter for the year must be between 1879 and " + DateTime.Now.AddYears(1).Year + ".\r\nParameter name: year";
            try
            {
                var response = new ReadAPI().GetModels("honda", 1800);
            }
            catch (ArgumentException ex)
            {
                caughtException = true;
                Assert.AreEqual(expectedExceptionMessage, ex.Message);
                Assert.AreEqual("year", ex.ParamName);
            }

            Assert.IsTrue(caughtException);
        }

        /// <summary>
        /// Test <see cref="ReadAPI.GetModels(string, int)"/> by passing in an 2199 as the year
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Live)]
        public void TestGetModels_Honda_InvalidYear2199()
        {
            bool caughtException = false;

            string expectedExceptionMessage = "The parameter for the year must be between 1879 and " + DateTime.Now.AddYears(1).Year + ".\r\nParameter name: year";
            try
            {
                var response = new ReadAPI().GetModels("honda", 2199);
            }
            catch (ArgumentException ex)
            {
                caughtException = true;
                Assert.AreEqual(expectedExceptionMessage, ex.Message);
                Assert.AreEqual("year", ex.ParamName);
            }

            Assert.IsTrue(caughtException);
        }

        /// <summary>
        /// Test requesting results for some manufacturer name that we know to be fictitious. We 
        /// would expect to get a good and safe response back, though with no results.
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Live)]
        public void TestGetModels_InvalidManufacturer()
        {
            var response = new ReadAPI().GetModels("hello_bad_manufacturer_name");
            Assert.AreEqual(0, response.Count);
            Assert.IsTrue(response.Message.Contains("successful"));
            Assert.AreEqual(response.Count, response.ModelsForMake.Count);
        }

        /// <summary>
        /// Test requesting results for some manufacturer name that we know to be fictitious. We 
        /// would expect to get a good and safe response back, though with no results.
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Live)]
        public void TestGetModels_InvalidManufacturer_2013()
        {
            var response = new ReadAPI().GetModels("hello_bad_manufacturer_name", 2013);
            Assert.AreEqual(0, response.Count);
            Assert.IsTrue(response.Message.Contains("successful"));
            Assert.AreEqual(response.Count, response.MakeModels.Count);
        }

        /// <summary>
        /// Test the <see cref="Make"/> constructor that takes in a <see cref="DataRow"/>
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Validate)]
        public void TestMakeConstructor()
        {
            DataTable dt = new DataTable("spGetMakes");
            dt.Columns.Add("MakeID");
            dt.Columns.Add("MakeName");
            dt.Columns.Add("Visible");
            dt.Columns.Add("Updated");
            dt.Rows.Add(new object[] { "3", "Ford", true, DateTime.Now.AddDays(-3).ToString() });

            Assert.AreEqual(1, dt.Rows.Count);

            var newMake = new Make(dt.Rows[0]);
            Assert.AreEqual(3, newMake.MakeID);
            Assert.AreEqual("Ford", newMake.MakeName);
        }

        /// <summary>
        /// Test the <see cref="Make"/> constructor that takes in a <see cref="DataRow"/> and make sure that it handles getting invalid data
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Validate)]
        public void TestMakeConstructor_InvalidData_MakeID()
        {
            DataTable dt = new DataTable("spGetMakes");
            dt.Columns.Add("MakeID");
            dt.Columns.Add("MakeName");
            dt.Columns.Add("Visible");
            dt.Columns.Add("Updated");
            dt.Rows.Add(new object[] { "null", "droF", false, DateTime.Now.AddDays(-1).ToString() });

            Assert.AreEqual(1, dt.Rows.Count);

            var newMake = new Make(dt.Rows[0]);
            Assert.AreEqual(0, newMake.MakeID);
            Assert.AreEqual("droF", newMake.MakeName);
        }

        /// <summary>
        /// Test the <see cref="Make"/> constructor that takes in a <see cref="DataRow"/> and make sure that it gracefully handles getting a table format that is incomplete
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Validate)]
        public void TestMakeConstructor_InvalidTable_MissingMakeIDColumn()
        {
            DataTable dt = new DataTable("spGetMakes");
            dt.Columns.Add("MakeName");
            dt.Rows.Add(new object[] { "Ford" });

            Assert.AreEqual(1, dt.Rows.Count);

            var newMake = new Make(dt.Rows[0]);
            Assert.AreEqual(0, newMake.MakeID);
            Assert.AreEqual("Ford", newMake.MakeName);
        }

        /// <summary>
        /// Test the <see cref="Make"/> constructor that takes in a <see cref="DataRow"/> and make sure that it gracefully handles getting a table format that is incomplete
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Validate)]
        public void TestMakeConstructor_InvalidTable_MissingMakeNameColumn()
        {
            DataTable dt = new DataTable("spGetMakes");
            dt.Columns.Add("MakeID");
            dt.Rows.Add(new object[] { "6" });

            Assert.AreEqual(1, dt.Rows.Count);

            var newMake = new Make(dt.Rows[0]);
            Assert.AreEqual(6, newMake.MakeID);
            Assert.AreEqual(string.Empty, newMake.MakeName);
        }

        /// <summary>
        /// Test the <see cref="Model"/> constructor that takes in a <see cref="DataRow"/>
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Validate)]
        public void TestModelConstructor()
        {
            DataTable dt = new DataTable("spGetModels");
            dt.Columns.Add("ModelID");
            dt.Columns.Add("ModelName");
            dt.Columns.Add("Visible");
            dt.Columns.Add("Updated");
            dt.Rows.Add(new object[] { "3", "Focus", true, DateTime.Now.AddDays(-3).ToString() });

            Assert.AreEqual(1, dt.Rows.Count);

            var newModel = new Model(dt.Rows[0]);
            Assert.AreEqual(3, newModel.ModelID);
            Assert.AreEqual("Focus", newModel.ModelName);
        }

        /// <summary>
        /// Test the <see cref="Model"/> constructor that takes in a <see cref="DataRow"/> and make sure that it handles getting invalid data
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Validate)]
        public void TestModelConstructor_InvalidData_ModelID()
        {
            DataTable dt = new DataTable("spGetModels");
            dt.Columns.Add("ModelID");
            dt.Columns.Add("ModelName");
            dt.Columns.Add("Visible");
            dt.Columns.Add("Updated");
            dt.Rows.Add(new object[] { "null", "Focus", false, DateTime.Now.AddDays(-1).ToString() });

            Assert.AreEqual(1, dt.Rows.Count);

            var newModel = new Model(dt.Rows[0]);
            Assert.AreEqual(0, newModel.ModelID);
            Assert.AreEqual("Focus", newModel.ModelName);
        }

        /// <summary>
        /// Test the <see cref="Model"/> constructor that takes in a <see cref="DataRow"/> and make sure that it gracefully handles getting a table format that is incomplete
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Validate)]
        public void TestModelConstructor_InvalidTable_MissingModelIDColumn()
        {
            DataTable dt = new DataTable("spGetModels");
            dt.Columns.Add("ModelName");
            dt.Rows.Add(new object[] { "Focus" });

            Assert.AreEqual(1, dt.Rows.Count);

            var newModel = new Model(dt.Rows[0]);
            Assert.AreEqual(0, newModel.ModelID);
            Assert.AreEqual("Focus", newModel.ModelName);
        }

        /// <summary>
        /// Test the <see cref="Model"/> constructor that takes in a <see cref="DataRow"/> and make sure that it gracefully handles getting a table format that is incomplete
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Validate)]
        public void TestModelConstructor_InvalidTable_MissingModelNameColumn()
        {
            DataTable dt = new DataTable("spGetModels");
            dt.Columns.Add("ModelID");
            dt.Rows.Add(new object[] { "6" });

            Assert.AreEqual(1, dt.Rows.Count);

            var newModel = new Model(dt.Rows[0]);
            Assert.AreEqual(6, newModel.ModelID);
            Assert.AreEqual(string.Empty, newModel.ModelName);
        }

        /// <summary>
        /// Test a simple serialization to try to replicate <c>GetAllMakes</c>
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Validate)]
        public void TestSerializeSampleData_GetAllMakes()
        {
            List<Make> vehichles = new List<Make>
            {
                new Make { MakeID = 1, MakeName = "Honda" },
                new Make { MakeID = 2, MakeName = "Tesla" }
            };

            GetAllVehicleMakes results = new GetAllVehicleMakes
            {
                AllVehicleMakes = vehichles,
                Count = vehichles.Count
            };

            string tempFile = System.IO.Path.GetTempFileName();
            SerializeConfig<GetAllVehicleMakes>.Serialize(tempFile, results);

            var deserializedResults = SerializeConfig<GetAllVehicleMakes>.DeSerialize(tempFile);
            Assert.AreEqual(2, deserializedResults.AllVehicleMakes.Count);
            Assert.AreEqual(deserializedResults.Count, deserializedResults.AllVehicleMakes.Count);
            Assert.IsTrue(deserializedResults.AllVehicleMakes.Any(x => x.MakeName == "Tesla"));
            Assert.IsTrue(deserializedResults.AllVehicleMakes.Any(x => x.MakeName == "Honda"));
        }

        /// <summary>
        /// Test a simple serialization to try to replicate <c>GetManufacturerDetails</c>
        /// </summary>
        [TestMethod, TestCategory(TestGroups.Validate), TestCategory(TestGroups.Serialization)]
        public void TestSerializeSampleData_GetManufacturerDetails()
        {
            GetManufacturerDetails results = new GetManufacturerDetails
            {
                ManufacturerDetails = new List<Manufacturer>()
                {
                    new Manufacturer()
                    {
                        ID = 22,
                        Name = "HONDA OF AMERICA MFG., INC.",
                        CommonName = "Honda",
                        AddressLine1 = "123 Foo Street",
                        City = "Santa Rosa",
                        StateProvince = "CA",
                        PostalCode = "956404",
                        Country = "USA",
                        LastUpdated = new DateTime(2015, 9, 2),
                        OtherManufacturerDetails = "Truck is another product.",
                        PrincipalFirstName = "Koichi Kondo",
                        PrincipalPosition = "CEO",
                        ContactEmail = "Unknown@unknown.com",
                        SubmittedOn = new DateTime(2014, 1, 1),
                        ManufacturerTypes = new List<ManufacturerType>() { new ManufacturerType() { Name = "Some type" } },
                        VehicleTypes = new List<VehicleType>() { new VehicleType() { Name = "Truck", IsPrimary = true }, new VehicleType() { Name = "Car", IsPrimary = false } }
                    }
                }
            };

            string tempFile = System.IO.Path.GetTempFileName();
            SerializeConfig<GetManufacturerDetails>.Serialize(tempFile, results);

            var deserializedResults = SerializeConfig<GetManufacturerDetails>.DeSerialize(tempFile);
            Assert.AreEqual(1, deserializedResults.ManufacturerDetails.Count);
            Assert.AreEqual(22, deserializedResults.ManufacturerDetails[0].ID);
            Assert.AreEqual("HONDA OF AMERICA MFG., INC.", deserializedResults.ManufacturerDetails[0].Name);
            Assert.AreEqual("Honda", deserializedResults.ManufacturerDetails[0].CommonName);
            Assert.AreEqual("123 Foo Street", deserializedResults.ManufacturerDetails[0].AddressLine1);
            Assert.AreEqual("Santa Rosa", deserializedResults.ManufacturerDetails[0].City);
            Assert.AreEqual("CA", deserializedResults.ManufacturerDetails[0].StateProvince);
            Assert.AreEqual("956404", deserializedResults.ManufacturerDetails[0].PostalCode);
            Assert.AreEqual("USA", deserializedResults.ManufacturerDetails[0].Country);
            Assert.AreEqual(new DateTime(2015, 9, 2), deserializedResults.ManufacturerDetails[0].LastUpdated);
            Assert.AreEqual("Truck is another product.", deserializedResults.ManufacturerDetails[0].OtherManufacturerDetails);
            Assert.AreEqual("Koichi Kondo", deserializedResults.ManufacturerDetails[0].PrincipalFirstName);
            Assert.AreEqual("CEO", deserializedResults.ManufacturerDetails[0].PrincipalPosition);
            Assert.AreEqual("Unknown@unknown.com", deserializedResults.ManufacturerDetails[0].ContactEmail);
            Assert.AreEqual(new DateTime(2014, 1, 1), deserializedResults.ManufacturerDetails[0].SubmittedOn);
        }

        /// <summary>
        /// Compare two files and make sure that the original file is at least a subset of the new file
        /// </summary>
        /// <param name="newFile">New file</param>
        /// <param name="originalFile">Original File</param>
        private static void CompareFiles(string newFile, string originalFile)
        {
            string newFileContents = System.IO.File.ReadAllText(newFile).Replace("\r", string.Empty).Replace("\n", string.Empty);
            string originalFileContents = System.IO.File.ReadAllText(originalFile).Replace("\r", string.Empty).Replace("\n", string.Empty);

            Assert.IsTrue(newFileContents.Contains(originalFileContents), "We expect the original to at least be a subset of the file we created.");
        }
    }
}
