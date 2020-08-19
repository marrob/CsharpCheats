
namespace Konvolucio.Cheat
{
    using System;
    using NUnit.Framework;

    class Bytes_Mask_Bytes_BitMask
    {
        [Test]
        public void BitMask64bit()
        {
            int start = 1;
            int length = 2;
            UInt64 mask = 0;

            for (int i = 0; i < length; i++)
                mask |= (UInt64)1 << i;
            mask <<= start;

            Assert.AreEqual(mask, 6);

            mask = ~mask;

            Assert.AreEqual(mask, 0xfffffffffffffff9);
        }
    }
}
