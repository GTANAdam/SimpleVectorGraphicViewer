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
        T ISerializer.Deserialize<T>(string data)
        {
            if (string.IsNullOrWhiteSpace(data)) throw new ArgumentNullException();

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
        string ISerializer.Serialize<T>(T obj)
        {
            if (obj == null) throw new ArgumentNullException();

            System.Xml.Serialization.XmlSerializer x = new(typeof(T));
            using StringWriter textWriter = new();
            x.Serialize(textWriter, obj);

            return textWriter.ToString();
        }
    }
}
