
namespace Konvolucio.Cheat
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    class Event
    {
        [Test]
        public void _0001_Subscribe()
        {
            var mc = new MockClass();
            bool rised = false;
            /*A névtelen metódus zárójele nem kötöelző*/
            mc.SampleEvent += (o, e) => { rised = true; };

            /*vagy zárójel nélkül*/
            mc.SampleEvent += (o, e) => rised = true;   
            mc.RiseSampleEvent();
            Assert.True(rised);
        }

        class MockClass
        {
            public EventHandler SampleEvent;
            public void RiseSampleEvent()
            {
                if (SampleEvent != null)
                    SampleEvent(this, EventArgs.Empty);
            }
        }
    }
}
