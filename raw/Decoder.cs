using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace raw
{
    public class Decoder
    {
        public String StationId;
        public String Date;
        public String ReportingTime1;
        public String ReportingTime2;
        public String ReportingTime3;
        public String GoodBurst;
        public String BadBurst;
        public String TotalBurst;
        public String Status;
        public String GPSstatus;
        public String WMOmsg;
        public String AT;
        public String ATmax;
        public String ATmin;
        public String Pressure;
        public String Battery;
        public String RainDaily;
        public String RainHourly;
        public String RH;
        public String SoilTemp;
        public String SoilMoisture;
        public String SunD;
        public String WindDir;
        public String WindSp;
        public String Health;
        public Boolean valid;
       

        void decode(Decoder d)
        {

        }

        public String separateParam(String line)
        {
            
            string[] lines = line.Split(',');
            this.StationId = lines[0].Remove(0, 1);
            this.Date = lines[1];
            this.ReportingTime1 = lines[2];
            this.Status = lines[3];
            this.Battery = lines[4].Remove(0, 4);
            this.RainHourly = lines[5].Remove(0, 4);
            this.SoilMoisture = lines[6].Remove(0, 4);
            String HealthBit = lines[7].Remove(0, 2);
            this.AT = lines[8].Remove(0, 5);
            this.ATmax = lines[9].Remove(0, 5);
            this.ATmin = lines[10].Remove(0, 5);
            this.WindSp = lines[11].Remove(0, 5);
            this.WindDir = lines[12].Remove(0, 5);
            this.Pressure = lines[13].Remove(0, 5);
            this.RH = lines[14].Remove(0, 5);
            this.RainDaily = lines[15].Remove(0, 5);
            this.SoilTemp= lines[16].Remove(0, 5);
            this.SunD = lines[17].Remove(0, 5);
            String s16 = lines[18].Remove(0, 5);
            String sts = lines[19];
            this.Health = lines[20];
            return this.StationId;
        }
    }

    public class DecoderARG 
    {
        public void decodeARG(Decoder d,String name)
        {
            QualityAnalysis qa = new QualityAnalysis();
            DAO dao = new DAO();
            try
            {
                d.AT = Convert.ToString((int.Parse(d.AT) / 10) - 40);
                d.ATmin = Convert.ToString(((Math.Abs((-1) * float.Parse(d.ATmin))) / 10) - 40);
                d.WindSp = Convert.ToString(((float.Parse(d.WindSp)) / 10.23) * 1.9439);
                d.Battery = Convert.ToString((float.Parse(d.Battery)) * 50 / 1023);
                //dao.getConnection();
                d.valid = qa.RangeCheck(d);
                if (d.valid == true)
                    dao.insertRow(d, name);
                
                //dao.closeConnection();
            }
            catch (Exception e)
            { }
        }
    }
    
    public class DecoderAWS
    {
        public void decodeAWS(Decoder d, String name)
        {
            QualityAnalysis qa = new QualityAnalysis();
            DAO dao = new DAO();
            float temp1;
            try
            {
                d.AT = Convert.ToString((int.Parse(d.AT) / 10) - 40);
                d.ATmin = Convert.ToString(((Math.Abs(float.Parse(d.ATmin))) / 10) - 40);
                d.ATmax = Convert.ToString(((Math.Abs(float.Parse(d.ATmin))) / 10) - 40);
                d.WindSp = Convert.ToString(((float.Parse(d.WindSp)) / 10.23) * 1.9439);
                d.Battery = Convert.ToString((float.Parse(d.Battery)) / 10);
                d.RainHourly = Convert.ToString((float.Parse(d.RainHourly)));
                d.SoilMoisture = Convert.ToString((float.Parse(d.SoilMoisture)));
                d.RainDaily = Convert.ToString((float.Parse(d.RainDaily)));
                d.SunD = Convert.ToString((float.Parse(d.SunD)));
                d.WindDir = Convert.ToString(float.Parse(d.WindDir) / 2.046);
                temp1 = float.Parse(d.Pressure);
                d.Pressure = Convert.ToString((temp1 / (temp1 + 0.0000001)) * ((temp1 / 10.23) + 800));
                d.SoilTemp = Convert.ToString((int.Parse(d.AT) / 10) - 40);
                d.RH = Convert.ToString(float.Parse(d.RH) / 10.23);
                //dao.getConnection();
                d.valid = qa.RangeCheck(d);
                if (d.valid == true)
                    dao.insertRow(d, name);
               
                //dao.closeConnection();
            }
            catch (Exception e)
            { }
        }
    }
}
