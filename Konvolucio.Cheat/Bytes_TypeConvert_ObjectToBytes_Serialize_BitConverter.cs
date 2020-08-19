
namespace Konvolucio.Cheat
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using NUnit.Framework;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Threading;
    using System.ComponentModel;

    using System.Runtime.InteropServices;

    class Bytes_TypeConvert_ObjectToBytes_Serialize_BitConverter
    {
        [Test]
        public void Uint64ToBytes_Marshal()
        {
            UInt64 value = 0x01;
            var bytes = Serialize(value);
            Assert.AreEqual(new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}, bytes);
        }

        [Test]
        public void Uint64ToBytes_Bitconverter() /*Ezt preferáljuk!*/
        {
            UInt64 value = 0x01;
            var bytes = BitConverter.GetBytes(value);
            Assert.AreEqual(new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, bytes);
        }

        /// <summary>
        /// Ez jó strukurára és osztályjra is
        /// Osztály esetén Az osztájly meg kell jeölni 
        /// [StructLayout(LayoutKind.Sequential, Pack = 1)]
        /// public class DisconnectionComplete
        /// Native tipusra is jó
        /// byte[] nativeTypeValue = Common.Serialize<UInt32>(0xFFFFFFFF);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Byte[] Serialize<T>(T obj)
        {
            int objsize = Marshal.SizeOf(typeof(T));
            Byte[] ret = new Byte[objsize];
            IntPtr buff = Marshal.AllocHGlobal(objsize);
            Marshal.StructureToPtr(obj, buff, true);
            Marshal.Copy(buff, ret, 0, objsize);
            Marshal.FreeHGlobal(buff);
            return ret;
        }
    }
}
