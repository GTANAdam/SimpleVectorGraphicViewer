using SimpleVectorGraphicViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVectorGraphicViewer.Factories.Interfaces
{
    interface IShapeFactory
    {
        Primitive Create(PrimitiveRaw entry);
    }
}
