
namespace Konvolucio.Cheat
{
    using NUnit.Framework;
    using System.Diagnostics;
    using System;
    using System.IO;

    [TestFixture]
    class App_Start_File
    {
        [Test]
        public void Run_Excel()
        {
            /*Excel Indul*/
            var myProcess = new Process();
            myProcess.StartInfo.FileName = "Excel";
            //myProcess.StartInfo.Arguments = "\"" + path + "\"";
            myProcess.Start();
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
