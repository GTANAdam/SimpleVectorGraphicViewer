using System.Collections.Generic;
using System.Drawing;
using System.IO;
using SimpleVectorGraphicViewer.Factories;
using SimpleVectorGraphicViewer.Factories.Interfaces;
using SimpleVectorGraphicViewer.Models;
using SimpleVectorGraphicViewer.Models.Primitives;
using System.Linq;

namespace SimpleVectorGraphicViewer.Serialization.Parsers
{
    internal static class Parser
    {
        /// <summary>
        /// Returns a list of Primitives from a given path
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        internal static IEnumerable<Primitive> ParseFile(ISerializer serializer, string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException();
            var fileData = File.ReadAllText(path);

            return ParseData(serializer, fileData);
        }

        /// <summary>
        /// Returns a list of primitives from given string dataa
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static IEnumerable<Primitive> ParseData(ISerializer serializer, string data)
        {
            IShapeFactory shapeFactory = new ShapeFactory();
            return serializer.Deserialize<PrimitiveRaw[]>(data).Select(entry => shapeFactory.Create(entry)).Where(entry => entry != null);
        }
    }
}
