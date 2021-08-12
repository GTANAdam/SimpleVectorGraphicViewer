using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVectorGraphicViewer.Serialization
{
    public interface ISerializer
    {
        T Deserialize<T>(string data) where T : class;
        void Deserialize<T>(string data, out T result) where T : struct;
        string Serialize<T>(T obj) where T : class;
        string Serialize<T>(ref T obj) where T : struct;

    }
}
