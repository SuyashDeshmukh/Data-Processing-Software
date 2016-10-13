using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Threading;
using System.Data;

namespace raw
{
    public class DAO
    {
        SqlConnection con = new SqlConnection("Data Source=LENOVO-PC;Initial Catalog=Project;Integrated Security=True");
        
        public void getConnection()
        {
            //con 
            con.Open();
        }

        public void closeConnection()
        {
            con.Close();
        }

        public void insertRow(Decoder d, String name)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into [" + name + "] values('" + DateTime.Now + "','" + d.Date + "','" + d.Date + "','" + d.Date + "','" + 1 + "','" + 1 + "','" + 1 + "','" + d.Health + "','" + d.Status + "','" + "N" + "','" + d.AT + "','" + d.ATmax + "','" + d.ATmin + "','" + d.Pressure + "','" + d.Battery + "','" + d.RainDaily + "','" + d.RainHourly + "','" + d.RH + "','" + d.SoilTemp + "','" + d.SoilMoisture + "','" + d.SunD + "','" + d.WindDir + "','" + d.WindSp + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
           
        }

        public void insertStation(Decoder d,String name, String state)
        {
            try
            {
                SqlCommand cmd10 = new SqlCommand("insert into Stations values ('" + name + "','"+DateTime.Now+"','"+state+"')", con);
                cmd10.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                System.Windows.Forms.MessageBox.Show(""+E);
            }
         
        }

        public String getStationType(String id)
        {
            //label1.Text = name1;
            SqlCommand cmd2 = new SqlCommand("select Prototype from a11 where SatId='" + id + "'", con);
            String type = Convert.ToString(cmd2.ExecuteScalar());
            return type;
        }

        public String getStationName(String id)
        {
            SqlCommand cmd1 = new SqlCommand("Select DatabaseTable from a11 where SatId='" + id + "'", con);
            String name1 = (String)cmd1.ExecuteScalar();
            return name1;
        }
        public String getStateName1(String name)
        {
            //System.Windows.Forms.MessageBox.Show(name);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select StateName from a11 where DatabaseTable='" + name + "';", con);
            String name1 = (String)cmd1.ExecuteScalar();
            con.Close();
            return name1;
        }


        public String getStateName(String id)
        {
            SqlCommand cmd1 = new SqlCommand("Select StateName from a11 where SatId='" + id + "'", con);
            String name1 = (String)cmd1.ExecuteScalar();
            return name1;
        }

        public DataTable getAllStates()
        {
            SqlCommand cmd1 = new SqlCommand("Select distinct(StateName),count(DatabaseTable) from a11 group by StateName;",con);
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(cmd1);
            ad.Fill(dt);
            return dt;
        }

        public DataSet viewer(String para,String table, String fDate, String tDate)
        {
            getConnection();
            DataSet ds=new DataSet();
            String query;
            if (fDate.Equals(null) && tDate.Equals(null))
            {
                 query = "select " + para + " from [" + table + "];";
            }
            else
            {
                 query = "select " + para + " from [" + table + "] where DateAndTime between '" + fDate + "'and'" + tDate + "';";
            }
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(ds,"ss");
            closeConnection();
            return ds;
        }

        public DataSet getStations(String name, String prototype)
        {
            getConnection();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("select * from a11 where StateName='"+name+"' and Prototype='"+prototype+"' order by DatabaseTable;",con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(ds, "0");
            closeConnection();
            return ds;
        }

        public DataSet getStates(string name)
        {
            getConnection();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("select distinct StateName from a11 order by StateName",con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(ds, "1");
            return ds;
        }

        public String test()
        {
            getConnection();
            //DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into [AASTHI] values('" + DateTime.Now + "','" + DateTime.Now + "','" + DateTime.Now + "','" + DateTime.Now + "','" + 1 + "','" + 1 + "','" + 1 + "','" + 1 + "','" +1 + "','" + "N" + "','" + 1 + "','" + 1 + "','" + 1 + "','" + 1 + "','" + 1 + "','" + 1 + "','" + 1 + "','" + 1 + "','" + 1 + "','" + 1 + "','" + 1 + "','" + 1 + "','" + 1 + "')", con);
                cmd.ExecuteNonQuery();
                return "ok";
            }
            catch (Exception E)
            {
                return "Error";
            }
        }

        public DataSet getfunctional(String dateTime1, String dateTime2)
        {
            DataSet d1 = new DataSet();
            String query = " Select distinct(DatabaseTable) from Stations where DateTime between '" + dateTime1 + "' and '" + dateTime2 + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(d1, "1");
            return d1;

        }

        public DataSet getnonfunctional(String fd, String td)
        {
            DataSet d1 = new DataSet();
            String query = " Select distinct(DatabaseTable) from a11 EXCEPT( select distinct(DatabaseTable) from Stations where DateTime between '" + fd + "' and '" +td + "' )";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(d1, "2");
            return d1;
        }

        public SqlDataReader rowretrieve()
        {
            con.Open();
            SqlCommand scmd = new SqlCommand("select * from RangeCheck",con);
            SqlDataReader dr = scmd.ExecuteReader();
           // con.Close();
            return dr;
            
        }
    }
}
