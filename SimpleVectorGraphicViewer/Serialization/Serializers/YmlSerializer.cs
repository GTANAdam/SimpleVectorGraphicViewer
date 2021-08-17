using System;

namespace SimpleVectorGraphicViewer.Serialization.Serializers
{
    public sealed class YmlSerializer : ISerializer
    {
        T ISerializer.Deserialize<T>(string data)
        {
            throw new NotImplementedException();
        }

        string ISerializer.Serialize<T>(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
