using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehaanikaStend_Charp
{
    class Sensors
    {

        private double _pullSensorValue;
        private double _torqueSensorValue;


        private double _tempADCValue;
        private double _rpmSensorValue;

        private string CalDataFileName = "caldata.xml";
        private const double _kelvinConst = 273.15;

        private CalibrationConfig calData;

        private LinearEQS linPullSensor;
        private LinearEQS linTorqueSensor;
        private LinearEQS linTemperatureSensor;

        public Sensors()
        {
            UpdateCaldata();
        }

        public void UpdateCaldata()
        {
            calData = CalibrationConfig.Deserialize(CalDataFileName);

            linPullSensor = new LinearEQS(calData.pullEtalonP0, calData.pullADCP0, calData.pullEtalonP1, calData.pullADCP1);
            linTorqueSensor = new LinearEQS(calData.torqueEtalonP0, calData.torqueADCP0, calData.torqueEtalonP1, calData.torqueADCP1);
            linTemperatureSensor = new LinearEQS(0, 0, calData.ADCRefVoltage, calData.ADCMaximum);
        }

        private double CalculatePullSensor()
        {
            return Math.Round(linPullSensor.y(_pullSensorValue), 0);
        }

        private double CalculateTorqueSensor()
        {
            return Math.Round(linTorqueSensor.y(_torqueSensorValue), 0);
        }

        private double CalculateR(double voltage_mVolts)
        {
            return (double) ( (calData.ADCRefVoltage / 1000) * calData.ADCBallResistance ) / ((double)((calData.ADCRefVoltage - voltage_mVolts)/1000) );
        }

        private double CalculateVoltageSensor()
        {
            return linTemperatureSensor.y(_tempADCValue);
        }

        private double CalculateT()
        {
            double mV = CalculateVoltageSensor();
            double R = CalculateR(mV);
            double temp1 = Math.Log((double)(R- calData.ADCBallResistance) / (double)calData.ResistanceR0, Math.E);
            double temp2 = (double)calData.ResistanceB / (double)calData.ResistanceT0;

            return calData.ResistanceB / (temp1 + temp2);
        }

        public double PullSensor
        {
            set
            {
                _pullSensorValue = value;
            }
            get
            {
                return CalculatePullSensor();
            }
        }

        public double TorqueSensor
        {
            set
            {
                _torqueSensorValue = value;
            }
            get
            {
                return CalculateTorqueSensor();
            }
        }

        public double TempSensorIn
        {
            set
            {
                _tempADCValue = value;
            }
        }

        public double TempSensorOut
        {
            get
            {
                return Math.Round(CalculateT() - _kelvinConst, 2);
            }
        }

        public double Rpm
        {
            set
            {
                _rpmSensorValue = value;
            }
            get
            {
                return _rpmSensorValue;
            }
        }
    }

    class LinearEQS
    {
        double ldy1, ldy2, ldx1, ldx2;

        public LinearEQS(double y1, double x1, double y2, double x2)
        {
            ldx1 = x1; ldx2 = x2; ldy1 = y1; ldy2 = y2;
        }

        private double CalculateK(double y1, double x1, double y2, double x2)
        {
            return y1 - (x1 * CalculateA(y1, x1, y2, x2) );
        }

        private double CalculateA(double y1, double x1, double y2, double x2)
        {
           return (y1 - y2) / (x1 - x2);
        }

        public double y(double x)
        {
            return a * x + k;
        }

        public double k
        {
            get
            {
                return this.CalculateK(ldy1, ldx1, ldy2, ldx2);
            }
        }
        public double a
        {
            get
            {
                return this.CalculateA(ldy1, ldx1, ldy2, ldx2);
            }
        }
    }
}
