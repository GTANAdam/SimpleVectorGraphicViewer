using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace SimpleVectorGraphicViewer.Serialization.Serializers
{
    public sealed class JsonSerializer : ISerializer
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
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(data));
                var ser = new DataContractJsonSerializer(typeof(T));
                var result = ser.ReadObject(ms) as T;
                ms.Close();

                return result;
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

            var ms = new MemoryStream();
            var ser = new DataContractJsonSerializer(typeof(T));
            ser.WriteObject(ms, obj);
            byte[] json = ms.ToArray();
            ms.Close();

            return Encoding.UTF8.GetString(json, 0, json.Length);
        }

        /// <summary>
        /// Deserialize data, where the out data is a reference to a struct
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="result"></param>
        public void Deserialize<T>(string data, out T result) where T : struct
        {
            try
            {
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(data));
                var ser = new DataContractJsonSerializer(typeof(T));
                result = (T)ser.ReadObject(ms);
                ms.Close();
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
        public string Serialize<T>(ref T obj) where T : struct
        {
            var ms = new MemoryStream();
            var ser = new DataContractJsonSerializer(typeof(T));
            ser.WriteObject(ms, obj);
            byte[] json = ms.ToArray();
            ms.Close();

            return Encoding.UTF8.GetString(json, 0, json.Length);
        }
    }
}
