using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
//using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using ZedGraph;

namespace MehaanikaStend_Charp
{

    public partial class mainWindow : Form
    {

        public static string fileName = "CalibrationSettings.xml";

        public enum ReadCommands : byte
        {
            CH1=0x35,
            CH2=0x36,
            TMP=0x37,
            RPM=0x38,
            ALL=0x40
        };

        static SerialPort serialPort = new SerialPort();
        Thread ReadSerialDataThread = new Thread(Read);

        bool bisConnected = false;

        static bool _isReading = false;
        public static bool _isSuspended = false;

        static Int32 updateRate = 500;

        static Sensors sensors;

        int TimerTickCount = 0;

        PointPairList TorquePoints = new PointPairList();
        PointPairList PullPoints = new PointPairList();
        PointPairList TempPoints = new PointPairList();
        PointPairList RPMPoints = new PointPairList();

        public mainWindow()
        {
            InitializeComponent();

            sensors = new Sensors();

            GeneratePortList(portList);

            Zed();

        }

        public void Zed()
        {
            GraphPane myPane = zed.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = "Mõõtetulemused";
            myPane.XAxis.Title.Text = "Time, ms";

            myPane.Y2Axis.Title.Text = "Tõmme, g";
            myPane.YAxis.Title.Text = "Vääne, g";

            // Generate a red curve with diamond symbols, and "Velocity" in the legend
            LineItem myCurve = myPane.AddCurve("Vääne",
                TorquePoints, Color.Red, SymbolType.None);
            // Fill the symbols with white
            myCurve.Symbol.Fill = new Fill(Color.White);

            // Generate a blue curve with circle symbols, and "Acceleration" in the legend
            myCurve = myPane.AddCurve("Tõmme",
                PullPoints, Color.Blue, SymbolType.None);
            // Fill the symbols with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the Y2 axis
            myCurve.IsY2Axis = true;

            // Generate a green curve with square symbols, and "Distance" in the legend
            myCurve = myPane.AddCurve("Temperatuur",
                TempPoints, Color.Green, SymbolType.None);
            // Fill the symbols with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the second Y axis
            myCurve.YAxisIndex = 1;

            // Generate a Black curve with triangle symbols, and "Energy" in the legend
            myCurve = myPane.AddCurve("RPM",
                RPMPoints, Color.DarkOrange, SymbolType.None);
            // Fill the symbols with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the Y2 axis
            myCurve.IsY2Axis = true;
            // Associate this curve with the second Y2 axis
            myCurve.YAxisIndex = 1;

            myPane.YAxis.Type = AxisType.Linear;

            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;

            // Make the Y axis scale red
            myPane.YAxis.Scale.FontSpec.FontColor = Color.Red;
            myPane.YAxis.Title.FontSpec.FontColor = Color.Red;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;
            myPane.YAxis.Scale.Max = 100;

            // Enable the Y2 axis display
            myPane.Y2Axis.IsVisible = true;
            // Make the Y2 axis scale blue
            myPane.Y2Axis.Scale.FontSpec.FontColor = Color.Blue;
            myPane.Y2Axis.Title.FontSpec.FontColor = Color.Blue;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            myPane.Y2Axis.MajorTic.IsOpposite = false;
            myPane.Y2Axis.MinorTic.IsOpposite = false;
            // Display the Y2 axis grid lines
            myPane.Y2Axis.MajorGrid.IsVisible = true;
            // Align the Y2 axis labels so they are flush to the axis
            myPane.Y2Axis.Scale.Align = AlignP.Inside;
            //myPane.Y2Axis.Scale.Min = 1.5;
            myPane.Y2Axis.Scale.Max = 100;

            // Create a second Y Axis, green
            YAxis yAxis3 = new YAxis("Temperatuur, °C");
            myPane.YAxisList.Add(yAxis3);
            yAxis3.Scale.FontSpec.FontColor = Color.Green;
            yAxis3.Title.FontSpec.FontColor = Color.Green;
            yAxis3.Color = Color.Green;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis3.MajorTic.IsInside = false;
            yAxis3.MinorTic.IsInside = false;
            yAxis3.MajorTic.IsOpposite = false;
            yAxis3.MinorTic.IsOpposite = false;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis3.Scale.Align = AlignP.Inside;
            yAxis3.Scale.Max = 100;

            Y2Axis yAxis4 = new Y2Axis("RPM, p/min");
            yAxis4.IsVisible = true;
            myPane.Y2AxisList.Add(yAxis4);
            yAxis4.Scale.FontSpec.FontColor = Color.DarkOrange;
            yAxis4.Title.FontSpec.FontColor = Color.DarkOrange;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis4.MajorTic.IsInside = false;
            yAxis4.MinorTic.IsInside = false;
            yAxis4.MajorTic.IsOpposite = false;
            yAxis4.MinorTic.IsOpposite = false;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis4.Scale.Align = AlignP.Inside;
            yAxis4.Type = AxisType.Linear;
            yAxis4.Scale.Max = 100;

            // Fill the axis background with a gradient
            // myPane.Chart.Fill = new Fill(Color.Gray, Color.Black, 45.0f);

            myPane.Chart.Fill = new Fill(Color.WhiteSmoke);

            // Tell ZedGraph to calculate the axis ranges
            // Note that you MUST call this after enabling IsAutoScrollRange, since AxisChange() sets
            // up the proper scrolling parameters
            zed.AxisChange();
            // Make sure the Graph gets redrawn
            zed.Invalidate();

        }

        public static void Read()
        {
            while (_isReading)
            {
                if (!_isSuspended)
                {
                    Channel3();
                    Thread.Sleep(200);
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }

        }

        private static void Channel3()
        {
            byte[] ReadValue = new byte[12];
            byte[] WriteCommand = new byte[1];

            WriteCommand[0] = (byte)ReadCommands.ALL;

            Array.Clear(ReadValue, 0, ReadValue.Length);

            try
            {

                serialPort.Write(WriteCommand, 0, 1);
                serialPort.Read(ReadValue, 0, ReadValue.Length);

                sensors.PullSensor = BitConverter.ToInt32(ReadValue, 0);
                sensors.TorqueSensor = BitConverter.ToInt32(ReadValue, 4);
                sensors.TempSensorIn = BitConverter.ToInt16(ReadValue, 8);
                sensors.Rpm = BitConverter.ToInt16(ReadValue, 10);

            }
            catch (TimeoutException) { }
            catch (System.IO.IOException) { }
            catch (SystemException) { }
        }

        public void GeneratePortList(ComboBox cb)
        {
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();
            // Display each port name to the console.
            foreach (string port in ports)
            {
                cb.Items.Add(port);
            }

            if ( cb.Items.Count != 0 )
            {
                cb.SelectedIndex = 0;
            }
            else
            {
                DialogResult rs =  MessageBox.Show("Ühetegi serial seadet pole, sulgeb programmi!", "Tõrge!", MessageBoxButtons.OK);
                if(rs > 0)
                {
                    this.Close();
                }
            }
        }

        private void portConnect_Click(object sender, EventArgs e)
        {
            if (!bisConnected)
            {
                try
                {
                    if (serialPort.IsOpen)
                    {
                        MessageBox.Show("Port on juba ühendatud \r\n");
                    }
                    else
                    {
                        serialPort.BaudRate = 115200;
                        serialPort.StopBits = StopBits.One;
                        serialPort.Parity = Parity.None;
                        serialPort.DataBits = 8;
                        serialPort.PortName = portList.SelectedItem.ToString();
                        serialPort.Open();

                        bisConnected = true;
                        portConnect.Text = "Vabasta";
                        portList.Enabled = false;

                        _isReading = true;

                        if (!ReadSerialDataThread.IsAlive)
                        {
                            ReadSerialDataThread = new Thread(Read);
                            ReadSerialDataThread.Start();
                        }
                    }
                }
                catch (Exception ex)
                {
                    serialPort.Close();
                    bisConnected = false;
                    _isReading = false;

                    MessageBox.Show(ex.ToString() + "\r\n");
                }
            }
            else
            {
                serialPort.Close();

                bisConnected = false;
                _isReading = false;

                portConnect.Text = "Ühenda";
                portList.Enabled = true;
            }


        }

        private void startCapture_Click(object sender, EventArgs e)
        {
            ClearGraphV2();
            UpdateXYDataSetsV2();

            calSettings.Enabled = false;

            graphUpdateRate.Enabled = true;
            startCapture.Enabled = false;
            stopCapture.Enabled = true;
            updateRateChanger.Enabled = false;
        }

        private void stopCapture_Click(object sender, EventArgs e)
        {
            calSettings.Enabled = true;

            graphUpdateRate.Enabled = false;
            stopCapture.Enabled = false;
            startCapture.Enabled = true;
            updateRateChanger.Enabled = true;
        }

        private void clearGraph_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Kas oled kindel et tahad graafiku kustutada!", "Puhasta graafik", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ClearGraphV2();
            }
        }

        private void ClearGraphV2()
        {
            PullPoints.Clear();
            TorquePoints.Clear();
            TempPoints.Clear();
            RPMPoints.Clear();

            TimerTickCount = 0;

            zed.AxisChange();
            zed.Invalidate();

        }

        private void graphUpdateRate_Tick(object sender, EventArgs e)
        {
            UpdateXYDataSetsV2();
        }

        private void UpdateXYDataSetsV2()
        {
            PullPoints.Add(TimerTickCount, sensors.PullSensor);
            TorquePoints.Add(TimerTickCount, sensors.TorqueSensor);
            TempPoints.Add(TimerTickCount, sensors.TempSensorOut);
            RPMPoints.Add(TimerTickCount, sensors.Rpm);

            // Update time X axis
            TimerTickCount += updateRate;

            zed.AxisChange();
            zed.Invalidate();
        }

        private void mainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _isReading = false;
            if (ReadSerialDataThread.IsAlive)
            {
                ReadSerialDataThread.Join();
            }
        }

        private void updateDisplays_Tick(object sender, EventArgs e)
        {
            pollValue.Text = sensors.PullSensor.ToString() + " g";
            torqueValue.Text = sensors.TorqueSensor.ToString() +" g";
            tempValue.Text = sensors.TempSensorOut + " °C";
            rpmValue.Text = sensors.Rpm + " p/min";
        }

        private void windowOpen_FormClosed(object sender, EventArgs e)
        {
            sensors.UpdateCaldata();
            _isSuspended = false;
        }

        private void calSettings_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                _isSuspended = true;
                Settings windowOpen = new Settings(serialPort);
                windowOpen.FormClosed += new FormClosedEventHandler(windowOpen_FormClosed);
                windowOpen.Show();
            }
            else
            {
                MessageBox.Show("Ühenda ennem Arduino Kaalu kontrolleriga!");
            }

        }

        private void updateRateChanger_ValueChanged(object sender, EventArgs e)
        {
            ClearGraphV2();

            NumericUpDown local = (NumericUpDown)sender;
            updateRate = (Int32)local.Value;
            graphUpdateRate.Interval = updateRate;
        }

        private void About_Click(object sender, EventArgs e)
        {
            AboutBox1 AB1 = new AboutBox1();
            AB1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Math.Log(0.1032, Math.E).ToString());
        }

    }
}
