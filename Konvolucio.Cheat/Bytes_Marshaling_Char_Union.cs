namespace Konvolucio.Cheat
{
    using NUnit.Framework;
    using System.Text;
    using System.Runtime.InteropServices;

    [TestFixture]
    class Bytes_Marshaling_Char
    {
        [Test]
        public void Union()
        {
            var x = new UNION_WITH_ARRAY();
            x.charArray = @"Hello World";
            Assert.AreEqual(x.charArray, new StringBuilder().Append(x.charArray2));
        }

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
        public struct UNION_WITH_ARRAY
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            [FieldOffset(0)]
            public string charArray;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            [FieldOffset(0)]
            public char[] charArray2;
        }

    }
}
