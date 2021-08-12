using System;
using System.IO;
//using System.Xml.Serialization;

namespace SimpleVectorGraphicViewer.Serialization.Serializers
{
    public sealed class XmlSerializer : ISerializer
    {
        /// <summary>
        /// Deserialize data, where the return data is of class type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns>T</returns>
        T ISerializer.Deserialize<T>(string data) where T : class
        {
            if (string.IsNullOrWhiteSpace(data)) return null;

            try
            {
                System.Xml.Serialization.XmlSerializer x = new(typeof(T)); //new XmlRootAttribute("primitives")
                var res = (T)x.Deserialize(new StringReader(data));
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Serialize data, where the parameter is of class type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>string</returns>
        string ISerializer.Serialize<T>(T obj) where T : class
        {
            if (obj == null) throw new Exception("obj can't be null");

            System.Xml.Serialization.XmlSerializer x = new(typeof(T));
            using StringWriter textWriter = new();
            x.Serialize(textWriter, obj);

            return textWriter.ToString();
        }

        /// <summary>
        /// Deserialize data, where the out data is a reference to a struct
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="result"></param>
        void ISerializer.Deserialize<T>(string data, out T result) where T : struct
        {
            result = default;
            if (string.IsNullOrWhiteSpace(data)) return;

            try
            {
                System.Xml.Serialization.XmlSerializer x = new(typeof(T));
                result = (T)x.Deserialize(new StringReader(data));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Serialize data, where the parameter is a reference to a struct
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        string ISerializer.Serialize<T>(ref T obj) where T : struct
        {
            System.Xml.Serialization.XmlSerializer x = new(typeof(T));
            using StringWriter textWriter = new();
            x.Serialize(textWriter, obj);

            return textWriter.ToString();
        }
    }
}
