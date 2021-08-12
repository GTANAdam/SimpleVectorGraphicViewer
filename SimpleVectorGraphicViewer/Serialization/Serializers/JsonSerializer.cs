using System;

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
                return SimpleJson.SimpleJson.DeserializeObject<T>(data);
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
            return SimpleJson.SimpleJson.SerializeObject(obj);
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
                result = SimpleJson.SimpleJson.DeserializeObject<T>(data);
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
            return SimpleJson.SimpleJson.SerializeObject(obj);
        }
    }
}
