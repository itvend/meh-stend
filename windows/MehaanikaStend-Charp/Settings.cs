using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace MehaanikaStend_Charp
{
    public partial class Settings : Form
    {

        private static SerialPort _SettingsSerial;
        private static CalibrationConfig calData = new CalibrationConfig();

        private static bool _ignoreLoad = true;
        private static bool _isChanged = false;

        //string CalDataFileName = "caldata.xml";

        public Settings(SerialPort _SettingsSerialRemote)
        {
            InitializeComponent();
            _SettingsSerial = _SettingsSerialRemote;
        }

        private Int32 GetADCChannel1()
        {
            Int32 _kaal = 0;
            byte[] ReadValue = new byte[4];
            byte[] WriteCommand = new byte[1];

            WriteCommand[0] = 0x35;

            Array.Clear(ReadValue, 0, ReadValue.Length);

            try
            {

                _SettingsSerial.Write(WriteCommand, 0, WriteCommand.Length);
                _SettingsSerial.Read(ReadValue, 0, ReadValue.Length);

                _kaal = BitConverter.ToInt32(ReadValue, 0);

                Array.Clear(ReadValue, 0, ReadValue.Length);

            }

            catch (TimeoutException) { }
            catch (System.IO.IOException) { }
            catch (SystemException) { }

            return _kaal;
        }

        private Int32 GetADCChannel2()
        {
            Int32 _kaal = 0;
            byte[] ReadValue = new byte[4];
            byte[] WriteCommand = new byte[1];

            WriteCommand[0] = 0x36;

            Array.Clear(ReadValue, 0, ReadValue.Length);

            try
            {

                _SettingsSerial.Write(WriteCommand, 0, WriteCommand.Length);
                _SettingsSerial.Read(ReadValue, 0, ReadValue.Length);

                _kaal = BitConverter.ToInt32(ReadValue, 0);

                Array.Clear(ReadValue, 0, ReadValue.Length);

            }

            catch (TimeoutException) { }
            catch (System.IO.IOException) { }
            catch (SystemException) { }

            return _kaal;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            calData = CalibrationConfig.Deserialize(mainWindow.fileName);

            pollEtalonP0.Text = calData.pullEtalonP0.ToString();
            pollEtalonP1.Text = calData.pullEtalonP1.ToString();
            pollADCP0.Text = calData.pullADCP0.ToString();
            pollADCP1.Text = calData.pullADCP1.ToString();

            torqueEtalonP0.Text = calData.torqueEtalonP0.ToString();
            torqueEtalonP1.Text = calData.torqueEtalonP1.ToString();
            torqueADCP0.Text = calData.torqueADCP0.ToString();
            torqueADCP1.Text = calData.torqueADCP1.ToString();

            ADCMaximumV.Text = calData.ADCMaximum.ToString();
            ADCRefVoltageV.Text = calData.ADCRefVoltage.ToString();
            ResistanceBV.Text = calData.ResistanceB.ToString();
            ResistanceR0V.Text = calData.ResistanceR0.ToString();
            ResistanceT0V.Text = calData.ResistanceT0.ToString();

            ADCBallResistanceV.Text = calData.ADCBallResistance.ToString();

            _ignoreLoad = false;

        }

        private void pollGetADCP0_Click(object sender, EventArgs e)
        {
            pollADCP0.Text = GetADCChannel1().ToString();
        }

        private void TextFieldsChanged(object sender, EventArgs e)
        {
            if (!_ignoreLoad)
            {
                _isChanged = true;
            }
        }

        private void SaveCalibrationData()
        {
            calData.pullEtalonP0 = Convert.ToInt32(pollEtalonP0.Text);
            calData.pullADCP0 = Convert.ToInt32(pollADCP0.Text);

            calData.pullEtalonP1 = Convert.ToInt32(pollEtalonP1.Text);
            calData.pullADCP1 = Convert.ToInt32(pollADCP1.Text);

            calData.torqueEtalonP0 = Convert.ToInt32(torqueEtalonP0.Text);
            calData.torqueADCP0 = Convert.ToInt32(torqueADCP0.Text);

            calData.torqueEtalonP1 = Convert.ToInt32(torqueEtalonP1.Text);
            calData.torqueADCP1 = Convert.ToInt32(torqueADCP1.Text);

            
            calData.ADCMaximum = Convert.ToInt32(ADCMaximumV.Text);
            calData.ADCRefVoltage = Convert.ToInt32(ADCRefVoltageV.Text);

            calData.ResistanceB = Convert.ToInt32(ResistanceBV.Text);
            calData.ResistanceR0 = Convert.ToInt32(ResistanceR0V.Text);
            calData.ResistanceT0 = Convert.ToInt32(ResistanceT0V.Text);

            calData.ADCBallResistance = Convert.ToInt32(ADCBallResistanceV.Text);

            CalibrationConfig.Serialize(mainWindow.fileName, calData);

            _isChanged = false;
        }

        private void pollSaveP0_Click(object sender, EventArgs e)
        {
            SaveCalibrationData();
        }

        private void pollGetADCP1_Click(object sender, EventArgs e)
        {
            pollADCP1.Text = GetADCChannel1().ToString();
        }

        private void torqueGetADCP0_Click(object sender, EventArgs e)
        {
            torqueADCP0.Text = GetADCChannel2().ToString();
        }

        private void torqueGetADCP1_Click(object sender, EventArgs e)
        {
            torqueADCP1.Text = GetADCChannel2().ToString();
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isChanged)
            {
                DialogResult digres = MessageBox.Show("Salvesta muutatused ?", "Hoiatus", MessageBoxButtons.YesNo);

                if (digres == DialogResult.Yes)
                {
                    SaveCalibrationData();
                }

                _isChanged = false;
            }
            _ignoreLoad = true;
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
           //
        }
    }
}
