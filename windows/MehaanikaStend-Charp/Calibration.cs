using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace MehaanikaStend_Charp
{
    #region -- Configuration Class --
    [Serializable]
    public class CalibrationConfig
    {

        Int32 _pullEtalonP0;
        Int32 _pullEtalonP1;
        Int32 _pullADCP0;
        Int32 _pullADCP1;

        Int32 _torqueEtalonP0;
        Int32 _torqueEtalonP1;
        Int32 _torqueADCP0;
        Int32 _torqueADCP1;

        Int32 _ADCMaximum;
        Int32 _ADCRefVoltage;
        Int32 _ResistanceB;
        Int32 _ResistanceR0;
        Int32 _ResistanceT0;

        Int32 _ADCBallResistance;

        public CalibrationConfig()
        {
            _pullEtalonP0 = 0;
            _pullEtalonP1 = 0;
            _pullADCP0 = 0;
            _pullADCP1 = 0;

            _torqueEtalonP0 = 0;
            _torqueEtalonP1 = 0;
            _torqueADCP0 = 0;
            _torqueADCP1 = 0;
			
			_ADCMaximum = 0;
			_ADCRefVoltage = 0;
			_ResistanceB = 0;
			_ResistanceR0 = 0;
			_ResistanceT0 = 0;

			_ADCBallResistance = 0;
			
        }

        public static void Serialize(string file, CalibrationConfig c)
        {
            System.Xml.Serialization.XmlSerializer xs
               = new System.Xml.Serialization.XmlSerializer(c.GetType());
            StreamWriter writer = File.CreateText(file);
            xs.Serialize(writer, c);
            writer.Flush();
            writer.Close();
        }

        public static CalibrationConfig Deserialize(string file)
        {
            CalibrationConfig c = new CalibrationConfig();
            try
            {
                System.Xml.Serialization.XmlSerializer xs
                   = new System.Xml.Serialization.XmlSerializer(
                      typeof(CalibrationConfig));
                StreamReader reader = File.OpenText(file);
                c = (CalibrationConfig)xs.Deserialize(reader);
                reader.Close();
            }
            catch (Exception) { }

            return c;
        }

        public Int32 pullEtalonP0
        {
            get { return _pullEtalonP0; }
            set { _pullEtalonP0 = value; }
        }

        public Int32 pullEtalonP1
        {
            get { return _pullEtalonP1; }
            set { _pullEtalonP1 = value; }
        }

        public Int32 pullADCP0
        {
            get { return _pullADCP0; }
            set { _pullADCP0 = value; }
        }

        public Int32 pullADCP1
        {
            get { return _pullADCP1; }
            set { _pullADCP1 = value; }
        }

        public Int32 torqueEtalonP0
        {
            get { return _torqueEtalonP0; }
            set { _torqueEtalonP0 = value; }
        }

        public Int32 torqueEtalonP1
        {
            get { return _torqueEtalonP1; }
            set { _torqueEtalonP1 = value; }
        }

        public Int32 torqueADCP0
        {
            get { return _torqueADCP0; }
            set { _torqueADCP0 = value; }
        }

        public Int32 torqueADCP1
        {
            get { return _torqueADCP1; }
            set { _torqueADCP1 = value; }
        }

        public Int32 ADCMaximum
        {
            get { return _ADCMaximum; }
            set { _ADCMaximum = value; }
        }

        public Int32 ADCRefVoltage
        {
            get { return _ADCRefVoltage; }
            set { _ADCRefVoltage = value; }
        }

        public Int32 ResistanceB
        {
            get { return _ResistanceB; }
            set { _ResistanceB = value; }
        }

        public Int32 ResistanceR0
        {
            get { return _ResistanceR0; }
            set { _ResistanceR0 = value; }
        }

        public Int32 ResistanceT0
        {
            get { return _ResistanceT0; }
            set { _ResistanceT0 = value; }
        }

        public Int32 ADCBallResistance
        {
            get { return _ADCBallResistance; }
            set { _ADCBallResistance = value; }
        }
    }
    #endregion
}
