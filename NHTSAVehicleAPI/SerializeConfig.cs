// <copyright file="SerializeConfig.cs" company="Dustin Ellis">
//     Copyright (c) Dustin Ellis. All rights reserved.
// </copyright>

namespace NHTSAVehicleAPI
{
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Serialization helper class
    /// </summary>
    /// <typeparam name="T">Type of class to serialize</typeparam>
    /// <remarks>
    /// From <seealso cref="https://stackoverflow.com/questions/364253/how-to-deserialize-xml-document"/>
    /// </remarks>
    public static class SerializeConfig<T> where T : class
    {
        /// <summary>
        /// Deserialize a class back into a class
        /// </summary>
        /// <param name="path">Path to the input file</param>
        /// <returns>The deserialized class</returns>
        public static T DeSerialize(string path)
        {
            T type;
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = XmlReader.Create(path))
            {
                type = serializer.Deserialize(reader) as T;
            }

            return type;
        }

        /// <summary>
        /// Deserialize a class back into a class
        /// </summary>
        /// <param name="str">Serialized XML string</param>
        /// <returns>The deserialized class</returns>
        public static T DeSerializeFromString(string str)
        {
            T type;
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(str))
            {
                type = serializer.Deserialize(reader) as T;
            }

            return type;
        }

        /// <summary>
        /// Serialize a class to an xml file
        /// </summary>
        /// <param name="path">Path to the output file</param>
        /// <param name="type">The class to be serialized</param>
        public static void Serialize(string path, T type)
        {
            var file = new FileInfo(path);
            Directory.CreateDirectory(file.DirectoryName);
            var serializer = new XmlSerializer(type.GetType());
            using (var writer = new FileStream(file.FullName, FileMode.Create))
            {
                serializer.Serialize(writer, type);
            }
        }

        /// <summary>
        /// Serialize a class tp xml
        /// </summary>
        /// <param name="type">The class to be serialized</param>
        /// <returns>String containing the serialized XML</returns>
        public static string Serialize(T type)
        {
            var serializer = new XmlSerializer(type.GetType());
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, type);
                return serializer.ToString();
            }
        }
    }
}
