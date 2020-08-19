using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;

namespace Konvolucio.Cheat
{
    [TestFixture]
    class Collection_Lambda_Join_Select
    {

        [Test]
        public void Lambda_ListValue()
        {
            var devices = new List<MockDeviceItem>();
            devices.Add(new MockDeviceItem(1, "frist"));
            devices.Add(new MockDeviceItem(2, "Second"));
            devices.Add(new MockDeviceItem(3, "Third"));
            devices.Add(new MockDeviceItem(4, "Fourth"));
            Debug.WriteLine(string.Join(",", devices.Select(n => n.Name)));
        }

        [Test]
        public void Lambda_Distint()
        {
            var devices = new List<MockDeviceItem>();
            devices.Add( new MockDeviceItem(1, "frist"));
            devices.Add(new MockDeviceItem(2, "frist"));
            devices.Add(new MockDeviceItem(3, "frist"));
            devices.Add(new MockDeviceItem(4, "frist"));

            /*A különböző címek számát adja vissza*/
            var distinctAddressCount = devices.Select(n => n.Address).Distinct().Count();
            Assert.AreEqual(4, distinctAddressCount);

            /*A különböző nevek számát adja vissza*/
            var disinctNameCount = devices.Select(n => n.Name).Distinct().Count();
            Assert.AreEqual(1, disinctNameCount);
        }

        public class MockDeviceItem
        {
            public int Address { get; set; }
            public string Name { get; set; }

            public MockDeviceItem(int address, string name)
            {
                Address = address;
                Name = name;
            }
        }
    }
}
