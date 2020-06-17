using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Modules
{
    class SysSerialPortModule
    {
        public static SerialPort serialPort = null;

        // ================
        // Open Serial Port
        // ================
        public static void OpenSerialPort()
        {
            try
            {
                if (serialPort == null)
                {
                    if (SysCurrentModule.GetCurrentSettings().WithCustomerDisplay == true)
                    {
                        String port = SysCurrentModule.GetCurrentSettings().CustomerDisplayPort;
                        Int32 baudRate = SysCurrentModule.GetCurrentSettings().CustomerDisplayBaudRate;

                        var portExists = SerialPort.GetPortNames().Any(x => x == port);
                        if (portExists)
                        {
                            serialPort = new SerialPort(port, baudRate, Parity.None, 8, StopBits.One);
                            serialPort.Open();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                serialPort = null;
            }
        }

        // =================
        // Close Serial Port
        // =================
        public static void CloseSerialPort()
        {
            try
            {
                if (serialPort != null)
                {
                    String line1 = SysCurrentModule.GetCurrentSettings().CustomerDisplayIfCounterClosedMessage;

                    WriteSeralPortMessage(line1, " ");

                    serialPort.Close();
                    serialPort = null;
                }
            }
            catch (Exception e)
            {
                serialPort = null;
            }
        }

        // ========================
        // Write Seral Port Message
        // ========================
        public static void WriteSeralPortMessage(String line1, String line2)
        {
            try
            {
                if (serialPort != null)
                {
                    String buf1 = "                    ";
                    if (line1.Length > buf1.Length) line1 = line1.Substring(1, buf1.Length);
                    else line1 = line1 + buf1.Substring(1, buf1.Length - line1.Length);

                    String buf2 = "                    ";
                    if (line2.Length > buf2.Length) line2 = line2.Substring(1, buf2.Length);
                    else line2 = line2 + buf2.Substring(1, buf2.Length - line2.Length);

                    serialPort.Write(line1 + line2);
                }
            }
            catch (Exception e)
            {
                serialPort = null;
            }
        }
    }
}
