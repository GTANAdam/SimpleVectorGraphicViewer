using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVectorGraphicViewer.Serialization
{
    public interface ISerializer
    {
        T Deserialize<T>(string data);

        string Serialize<T>(T obj);
    }
}
