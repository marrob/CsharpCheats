

namespace Konvolucio.Cheat
{
    using System.ComponentModel;
    using NUnit.Framework;
    using System.Diagnostics;

    [TestFixture]
    public class News
    {
        class MockClass
        {
            public string Name { get; set; }

            private int _month = 7;  // Backing store
            public int Month
            {
                get => _month;
                set
                {
                    if ((value > 0) && (value < 13))
                    {
                        _month = value;
                    }
                }
            }

            public MockClass()
            {

            }
            public MockClass(string name)
            {
                Name = name;
            }
        };
        

        [Test]
        public void NewInstancWithAccessor()
        {
            var mock1 = new MockClass { Name = "Homer Simpson" };
            var mock2 = new MockClass("Homer Simpson");

        }
    }
}
