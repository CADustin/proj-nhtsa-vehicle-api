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
    /// Serialization helper class.
    /// </summary>
    /// <typeparam name="T">Type of class to serialize.</typeparam>
    public static class SerializeConfig<T>
        where T : class
    {
        /// <summary>
        /// Deserialize the type to XML using the <seealso cref="DataContractSerializer"/>.
        /// </summary>
        /// <param name="fileName">The file to read the XML from.</param>
        /// <returns>The deserialized class.</returns>
        public static T Deserialize(string fileName)
        {
            T type;
            var serializer = new DataContractSerializer(typeof(T));
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(fileName);
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
        /// <param name="fileName">The file to read the XML from.</param>
        /// <returns>The deserialized class.</returns>
        public static T DeserializeUsingXmlSerializer(string fileName)
        {
            T type;
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = XmlReader.Create(fileName))
            {
                type = serializer.Deserialize(reader) as T;
            }

            return type;
        }

        /// <summary>
        /// Serialize the type to XML using the <seealso cref="DataContractSerializer"/>.
        /// </summary>
        /// <param name="fileName">The file where we will store the serialized xml.</param>
        /// <param name="type">The class to be serialized.</param>
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
        /// Serialize a class to an xml file.
        /// </summary>
        /// <param name="fileName">The file where we will store the serialized xml.</param>
        /// <param name="type">The class to be serialized.</param>
        public static void SerializeUsingXmlSerializer(string fileName, T type)
        {
            var serializer = new XmlSerializer(type.GetType());
            using (var writer = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(writer, type);
            }
        }
    }
}