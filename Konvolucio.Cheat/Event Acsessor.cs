
namespace Konvolucio.Cheat
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    class EventAcessor
    {
        MockClass _mockClass = new MockClass();

        event EventHandler CustomEvent
        {
            add { _mockClass.SampleEvent += value; }
            remove { _mockClass.SampleEvent -= value; }
        }

        event EventHandler CustomEvent2
        {
            add => _mockClass.SampleEvent += value;
            remove => _mockClass.SampleEvent -= value;
        }

        [Test]
        public void _0001_Subscribe()
        {
            bool rised = false;
            /*A névtelen metódus zárójele nem kötöelző*/
            CustomEvent += (o, e) => { rised = true; };

            /*vagy zárójel nélkül*/
            CustomEvent += (o, e) => rised = true;   
            _mockClass.RiseSampleEvent();
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
