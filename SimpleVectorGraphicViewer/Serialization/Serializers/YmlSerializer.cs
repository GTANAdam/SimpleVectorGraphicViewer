using System;

namespace SimpleVectorGraphicViewer.Serialization.Serializers
{
    public sealed class YmlSerializer : ISerializer
    {
        public void Deserialize<T>(string data, out T result) where T : struct
        {
            throw new NotImplementedException();
        }

        public string Serialize<T>(ref T obj) where T : struct
        {
            throw new NotImplementedException();
        }

        T ISerializer.Deserialize<T>(string data) where T : class
        {
            throw new NotImplementedException();
        }

        string ISerializer.Serialize<T>(T obj) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
