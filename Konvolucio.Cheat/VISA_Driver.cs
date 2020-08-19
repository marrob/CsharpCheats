
namespace Konvolucio.Cheat
{
    using NUnit.Framework;
    using System.Diagnostics;
    using System;
    using System.IO;
    using Ivi.Visa.Interop;

    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Agilent
    /// IVI-COM driver and VISA-COM
    /// I/O programming examples in
    /// Microsoft Visual C#
    /// Application Note
    /// https://www.keysight.com/zz/en/assets/7018-07362/application-notes/5991-0603.pdf?success=true
    /// 
    /// Reference 
    /// "C:\Program Files\IVI Foundation\VISA\VisaCom64\GlobMgr.dll"
    /// Majd ez jelenik meg a listaban:
    /// VisaComLib
    /// 
    /// 
    /// Error:
    /// Interop type 'FormattedIO488Class' cannot be embedded.Use the applicable interface instead.
    /// .NET 4.0 allows primary interop assemblies (or rather, the bits of it that you need) 
    /// to be embedded into your assembly so that you don't need to deploy them alongside your application. 
    /// For whatever reason, this assembly can't be embedded - but it sounds like that's not a problem for you.
    /// Just open the Properties tab for the assembly in Visual Studio 2010 and set "Embed Interop Types" to "False".
    /// 
    /// </summary>



    [TestFixture]
    class VISA_Driver
    {



        [Test]
        public void BK8600()
        {

            //EC7::0x8800::802197036737120008::INSTR
            string srcAddress  = "USB0::0x2EC7::0x8800::802197036737120008::INSTR";
            ResourceManager rMgr = new ResourceManagerClass();
            FormattedIO488 src = new FormattedIO488Class();
            var  addresses = rMgr.FindRsrc("USB?*");

            var s = rMgr.Description;
            var x = rMgr.SpecVersion;

            src.IO = (IMessage)rMgr.Open(srcAddress, AccessMode.NO_LOCK, 2000, "");
            src.IO.Timeout = 2000;
            src.IO.Clear();
            src.WriteString("*RST; *OPC ?", true);
            src.WriteString("*IDN?", true);
            string temp = src.ReadString();


        }

        [Test]
        public void RunNotepadOrNpp()
        {
            string path = @"MyTest.txt";

            if (!File.Exists(path))
            {
                string[] createText = { "Hello", "And", "Welcome" };
                File.WriteAllLines(path, createText);
            }

            var myProcess = new Process();
            myProcess.StartInfo.Arguments = "\"" + path + "\"";
            myProcess.StartInfo.FileName = "Notepad++";
            try
            {
                myProcess.Start();
            }
            catch (Exception)
            {
                myProcess.StartInfo.FileName = "Notepad";
                myProcess.Start();
            }
        }
    }
}
