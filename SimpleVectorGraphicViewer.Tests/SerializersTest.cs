using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SimpleVectorGraphicViewer;
using SimpleVectorGraphicViewer.Serialization.Serializers;

namespace SimpleVectorGraphicViewer.Tests
{
    [TestClass]
    public class Serializers
    {
        public class TestData
        {
            public string Prop1 { get; set; }
            public int Prop2 { get; set; }
            public float Prop3 { get; set; }
            public bool Prop4 { get; set; }
        }

        const string serData = "{\"Prop1\":\"Test\",\"Prop2\":420,\"Prop3\":420.69,\"Prop4\":true}";
        readonly TestData data = new TestData { Prop1 = "Test", Prop2 = 420, Prop3 = 420.69f, Prop4 = true };

        [TestMethod]
        public void JsonSerializer()
        {
            Serialization.ISerializer serializer = new JsonSerializer();
            var serialized = serializer.Serialize(data);
            Assert.AreEqual(serialized, serData);
        }

        [TestMethod]
        public void JsonDeserializer()
        {
            Serialization.ISerializer serializer = new JsonSerializer();
            var deserialized = serializer.Deserialize<TestData>(serData);
            Assert.AreEqual(deserialized.ToString(), data.ToString());
        }
    }
}
