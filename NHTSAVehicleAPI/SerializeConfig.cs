// <copyright file="SerializeConfig.cs" company="Dustin Ellis">
//     Copyright (c) Dustin Ellis. All rights reserved.
// </copyright>

namespace NHTSAVehicleAPI
{
    using System.IO;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Serialization helper class
    /// </summary>
    /// <typeparam name="T">Type of class to serialize</typeparam>
    /// <remarks>From <seealso cref="https://stackoverflow.com/questions/364253/how-to-deserialize-xml-document"/></remarks>
    public static class SerializeConfig<T> where T : class
    {
        public static T Deserialize(string path)
        {
            T type;
            var serializer = new DataContractSerializer(typeof(T));
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(path);
                    writer.Flush();
                    stream.Position = 0;

                    type = (T)serializer.ReadObject(stream);
                }
            }

            return type;
        }

        /// <summary>
        /// Deserialize data from the NHTSA API into an object.
        /// </summary>
        /// <remarks>
        /// This deserializer is using the <seealso cref="XmlSerializer"/> to deserialize the API.
        /// </remarks>
        /// <param name="path">Path to the input file</param>
        /// <returns>The deserialized class</returns>
        public static T DeserializeUsingXmlSerializer(string path)
        {
            T type;
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = XmlReader.Create(path))
            {
                type = serializer.Deserialize(reader) as T;
            }

            return type;
        }

        public static void Serialize(string fileName, T type)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(T));
            var settings = new XmlWriterSettings { Indent = true };
            using (var writer = XmlWriter.Create(fileName, settings))
            {
                serializer.WriteObject(writer, type);
            }
        }

        /// <summary>
        /// Serialize a class to an xml file
        /// </summary>
        /// <param name="path">Path to the output file</param>
        /// <param name="type">The class to be serialized</param>
        public static void SerializeUsingXmlSerializer(string path, T type)
        {
            var file = new FileInfo(path);
            Directory.CreateDirectory(file.DirectoryName);
            var serializer = new XmlSerializer(type.GetType());
            using (var writer = new FileStream(file.FullName, FileMode.Create))
            {
                serializer.Serialize(writer, type);
            }
        }
    }
}