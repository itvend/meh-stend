using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace MehaanikaStend_Charp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] ports = SerialPort.GetPortNames();

            if ( !(ports.Length > 0))
            {
                MessageBox.Show("Ühetegi serial seadet pole, sulgen programmi!", "Tõrge!", MessageBoxButtons.OK);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new mainWindow());
            }
        }
    }
}
