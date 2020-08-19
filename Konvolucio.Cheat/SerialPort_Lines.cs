
namespace Konvolucio.Cheat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using System.IO.Ports;
    using System.Diagnostics;

    [TestFixture]
    class SerialPort_Lines
    {
        [Test]
        public void UnitTest_ReadLine()
        {
            var app = new App();
            app.GetVcells();
            app.Close();
        }
    }

    public class App
    {


        public void GetPortNames()
        {
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();

            Console.WriteLine("The following serial ports were found:");

            // Display each port name to the console.
            foreach (string port in ports)
            {
                Console.WriteLine(port);
            }

            Console.ReadLine();
        }

        private SerialPort _sp;

        public App()
        {
            Open("COM8");
            for (int i = 0; i < 1000; i++)
                GetVcells();
            Console.Read();
        }

        public void Open(string port)
        {
            if (_sp != null)
                throw new ArgumentException("Port alredy open");
            try
            {
                _sp = new SerialPort(port);
                _sp.ReadTimeout = 1000;
                _sp.NewLine = "\n";
                _sp.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetVcells()
        {
            _sp.WriteLine("VCELLS?\n");
            Debug.WriteLine(_sp.ReadLine());
        }

        public void Close()
        {
            if (_sp != null)
            {
                if (_sp.IsOpen)
                {
                    _sp.Close();
                }

            }
        }
    }


}
