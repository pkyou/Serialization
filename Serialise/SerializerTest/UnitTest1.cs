using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serializer;

namespace SerializerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TestClass testClass = new TestClass()
            {
                TestNumber = 123,
                TestString = "test"
            };
            Serialization serialization=new Serialization();
            serialization.SerializeToFile(testClass, Environment.CurrentDirectory,"test.txt");

            TestClass deserialiedClass =
                serialization.Deserialize<TestClass>(Environment.CurrentDirectory + "\\test.txt");
            Assert.AreEqual(123,deserialiedClass.TestNumber);
            Assert.AreEqual("test",deserialiedClass.TestString);
        }
    }

    [Serializable]
    class TestClass
    {
        public string TestString { get; set; }
        public int TestNumber { get; set; }

    }
}
