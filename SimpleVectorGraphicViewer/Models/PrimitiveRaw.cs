using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SimpleVectorGraphicViewer.Models
{
    [DataContract]
    [XmlType("primitive")]
    public class PrimitiveRaw
    {
        [XmlElement("type")]
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [XmlElement("a")]
        [DataMember(Name = "a")]
        public string A { get; set; } // Line/Triangle/Rectangle

        [XmlElement("b")]
        [DataMember(Name = "b")]
        public string B { get; set; } // Line/Triangle/Rectangle

        [XmlElement("c")]
        [DataMember(Name = "c")]
        public string C { get; set; } // Triangle/Rectangle

        [XmlElement("d")]
        [DataMember(Name = "d")]
        public string D { get; set; } // Rectangle

        [XmlElement("color")]
        [DataMember(Name = "color")]
        public string Color { get; set; }

        [XmlElement("center")]
        [DataMember(Name = "center")]
        public string Center { get; set; } // Circle

        [XmlElement("radius")]
        [DataMember(Name = "radius")]
        public float Radius { get; set; } // Circle

        [XmlElement("filled")]
        [DataMember(Name = "filled")]
        public bool Filled { get; set; } // Circle/Triangle/Rectangle
    }

}
