using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;


namespace raw
{
    class QualityAnalysis
    {
        DAO d1 = new DAO();
        public Boolean RangeCheck(Decoder d)
        {
            SqlDataReader dr = d1.rowretrieve();

            Double AT=Convert.ToDouble(d.AT);
            Double ATmax = Convert.ToDouble(d.ATmax);
            Double ATmin = Convert.ToDouble(d.ATmin);
            Double Pressure = Convert.ToDouble(d.Pressure);
            Double Battery = Convert.ToDouble(d.Battery);
            Double RainDaily = Convert.ToDouble(d.RainDaily);
            Double RH = Convert.ToDouble(d.RH);
            Double SoilTemp = Convert.ToDouble(d.SoilTemp);
            Double SunD = Convert.ToDouble(d.SunD);
            Double WindDir = Convert.ToDouble(d.WindDir);
            Double WindSp = Convert.ToDouble(d.WindSp);
            int count = 0;
          

            while (dr.Read())
            {
                
                    if (AT < (Double)dr[0] && AT > (Double)dr[1])
                        count++;
                    if (ATmax < (Double)dr[2] && ATmax > (Double)dr[3])
                        count++;
                    if (ATmin < (Double)dr[4] && ATmin > (Double)dr[5])
                        count++;
                    if (Battery < (Double)dr[6] && Battery > (Double)dr[7])
                        count++;
                    if (RainDaily < (Double)dr[8] && RainDaily > (Double)dr[9])
                        count++;
                    if (RH < (Double)dr[10] && RH > (Double)dr[11])
                        count++;
                    if (Pressure < (Double)dr[12] && Pressure > (Double)dr[13])
                        count++;
                    if (SoilTemp < (Double)dr[14] && SoilTemp > (Double)dr[15])
                        count++;
                    if (SunD < (Double)dr[16] && SunD > (Double)dr[17])
                        count++;
                    if (WindDir < (Double)dr[18] && WindDir > (Double)dr[19])
                        count++;
                    if (WindSp < (Double)dr[20] && WindSp > (Double)dr[21])
                        count++;
                
            }
            //if (count >0)
                return true;
            /*else
            {
                return false;
            }*/
 
        }
    }
}
