
namespace Konvolucio.Cheat
{
    using NUnit.Framework;
    using System.Diagnostics;
    using System;
    using System.IO;
    using System.Text;


    [TestFixture]
    class File_Text_Stream
    {
        [Test]
        public void Simples_TextWirte_Append()
        {
            string path = @"c:\temp\MyTest.txt";

            if (!File.Exists(path))
            {
                string[] createText = { "Hello", "And", "Welcome" };
                File.WriteAllLines(path, createText);
            }

            string appendText = "This is extra text" + Environment.NewLine;
            File.AppendAllText(path, appendText);

            string[] readText = File.ReadAllLines(path);
            foreach (string s in readText)
            {
                Debug.WriteLine(s);
            }
        }

        [Test]
        public void File_StreamWriter()
        {
            string path = "MyTest.txt";
            string[] lines = new string[] { "Hello", "And", "Welcome" };

            using (StreamWriter sw = new StreamWriter(path, false))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    sw.WriteLine(lines[i]);
                }
            }
        }

        [Test]
        public void File_Lines_StreamReader()
        {
            string path = "MyTest.txt";
            string[] lines = new string[] { };

            int row = 1;
            string line = string.Empty;
            using (StreamReader sr = new StreamReader(path))
            {
                do
                {
                    line = sr.ReadLine();
                    Array.Resize(ref lines, row);
                    lines[row - 1] = line;
                    row++;
                } while (line != null);
            }
        }

        [Test]
        public void File_Lines_ReadAllBytes()
        {
            string path = "MyTest.txt";

            if (!File.Exists(path))
                throw new Exception("File does not exits");

            byte[] bytes = File.ReadAllBytes(path);
            string line = string.Empty;
            for (int i = 0; i < bytes.Length; i++)
                line += bytes[i];

            string[] stringSeparators = new string[] { "\r\n" };
            string[] lines = line.Split(stringSeparators, StringSplitOptions.None);

        }

        [Test]
        public void BinaryFile_Write()
        {
            string path = "MyTest.txt";

            if (File.Exists(path))
                File.Delete(path);

            byte[] data = Encoding.ASCII.GetBytes("Hello World_FileStram");

            using (FileStream fs = new FileStream(path, FileMode.CreateNew))
            {
                fs.Write(data, 0, data.Length);
            }

            var myProcess = new Process();
            myProcess.StartInfo.FileName = "Notepad";
            myProcess.StartInfo.Arguments = "\"" + path + "\"";
            myProcess.Start();
        }
    }
}
