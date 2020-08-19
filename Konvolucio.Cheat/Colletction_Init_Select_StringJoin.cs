namespace Konvolucio.Cheat
{
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel;
    using NUnit.Framework;
    using System.Diagnostics;

    [TestFixture]
    class Colletction_Init_Join
    {
        public static MockSignalCollection Signals { get; } = new MockSignalCollection();

        [Test]
        public void Init()
        {
            Signals.AddRange
            (
                new MockSignalItem[]
                {
                    new MockSignalItem("First","0.00"),
                    new MockSignalItem("Second", "0.00")
                }
            );
        }


        [Test]
        public void Select_Join()
        {
            var signal = new MockSignalCollection();
            signal.AddRange
            (
                new MockSignalItem[]
                {
                    new MockSignalItem("First","0.00"),
                    new MockSignalItem("Second", "0.00")
                }
            );
            var str = string.Join("\r\n", signal.Select(n => n.Name));
            Debug.WriteLine(str);
            Assert.AreEqual("First\r\nSecond",str);
        }
    }



    public class MockSignalItem
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public MockSignalItem(string name, string Value)
        {
            Name = name;
        }
    }

    public class MockSignalCollection : List<MockSignalItem>
    {

    }


}
