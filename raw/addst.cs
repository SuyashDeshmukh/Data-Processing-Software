using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace raw
{
    public partial class addst : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LENOVO-PC;Initial Catalog=Project;Integrated Security=True");
        DAO d = new DAO();
        String name;
        public String[] para;
        String prototype = null;
        private void addst_Load(object sender, EventArgs e)
        {

        }

        public addst()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       /* private void Form5_Load(object sender, EventArgs e)
        {
            
        }*/

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            
            con.Open();
            prototype = comboBox1.Text.ToString();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("select DatabaseTable from a11 where Prototype='"+prototype+"' order by DatabaseTable", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(ds, "a");
            //con.Close();
            listBox2.DataSource = ds.Tables["a"];
            listBox2.DisplayMember = "DatabaseTable";
            con.Close();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            name = listBox2.Text.ToString();
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select * from ["+name+"];",con);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd1);
            ad.Fill(ds, "b");
            dataGridView1.DataSource = ds.Tables["b"];

            //To get all sensor list in listbox1
            SqlCommand cmd2 = new SqlCommand("Select SensorList from a11 where DatabaseTable='" + name + "';", con);
            SqlDataReader rd11 = cmd2.ExecuteReader();
            rd11.Read();
            String param = (string)rd11["SensorList"];
            para = param.Split(',');
            for (int i = 0; i < para.Length; i++)
            {
                listBox1.Items.Add(para[i]);
            }
            rd11.Close();

            //To get all details of selected Station in groupbox1
            SqlCommand cmd3 = new SqlCommand("select * from a11 where DatabaseTable='"+name+"';",con);
            SqlDataReader rd = cmd3.ExecuteReader();
            while (rd.Read())
            {
                //rd.Read();
                label6.Text = (String)rd[1];
                textBox4.Text = (String)rd[1];
                textBox5.Text = (String)rd[3];
                textBox10.Text = (String)rd[18];
                textBox17.Text = (String)rd[10];
                textBox16.Text = (String)rd[11];
                textBox15.Text = (String)rd[12];
                textBox6.Text = (String)rd[6];
                textBox20.Text = (String)rd[14];
                textBox9.Text = (String)rd[2];
                textBox15.Text = (String)rd[12];
                textBox33.Text = rd[9].ToString();
                textBox20.Text = rd[14].ToString();
                textBox23.Text = rd[15].ToString();
                textBox22.Text = rd[16].ToString();
                textBox11.Text = rd[19].ToString();
                checkBox1.Checked = true;
                checkBox2.Checked = true;
            }

            
            con.Close();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        /*private void button15_Click(object sender, EventArgs e)
        {
            String parameter = listBox1.Text.ToString();
            String ab;
            int i = 23;
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from a11 where DatabaseTable='" + name + "';", con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                while (true)
                {
                    if (rd[i].Equals(null))
                    {
                        i++;
                        continue;
                    }
                    else
                    {
                        ab = rd[i].ToString();
                        i++;
                        if (ab.Equals(parameter))
                            break;
                    }
                }
                textBox3.Text = parameter;
                textBox30.Text = rd[i].ToString();
                textBox29.Text = rd[i + 1].ToString();
                textBox36.Text = "0";
                textBox32.Text = rd[i + 2].ToString();
                textBox34.Text = rd[i + 5].ToString();
                textBox35.Text = rd[i + 6].ToString();
                textBox26.Text = rd[i + 7].ToString();
                checkBox3.Checked = true;
            }
            con.Close();
        }*/

        private void button4_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Drop table ["+name+"]",con);
            cmd.ExecuteScalar();
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            String pro = null;
            pro = comboBox1.Text.ToString();
            con.Close();
            //MessageBox.Show(pro);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //name = listBox1.Text.ToString();
            MessageBox.Show(name);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * into ["+textBox5.Text+"] from ["+name+"];",con);
            cmd.ExecuteScalar();
            SqlCommand cmd1 = new SqlCommand("insert into a11 select NoSensors,StationName,SatID,DatabaseTable,WMOmsgGen,NationalStnNo,TxTime,SensorList,MesIntv,Prototype,Latitude,Longitude,Altitude,MarsdenSq,CallSign,VapourPr,MeanPr,Installed,StateName,ProjectName,WMOBlockNo,WMOStnNo,WMOAssign,[00SensorName],[00SensorID],[00Equation],[00RightDigit],[00SensorPos],[00Enable],[00HighLimit],[00StdDiv],[00LowLimit],[00Stats],[01SensorName],[01SensorID],[01Equation],[01RightDigit],[01SensorPos],[01Enable],[01HighLimit],[01StdDiv],[01LowLimit],[01Stats],[02SensorName],[02SensorID],[02Equation],[02RightDigit],[02SensorPos],[02Enable],[02HighLimit],[02StdDiv],[02LowLimit],[02Stats],[03SensorName],[03SensorID],[03Equation],[03RightDigit],[03SensorPos],[03Enable],[03HighLimit],[03StdDiv],[03LowLimit],[03Stats],[04SensorName],[04SensorID],[04Equation],[04RightDigit],[04SensorPos],[04Enable],[04HighLimit],[04StdDiv],[04LowLimit],[04Stats],[05SensorName],[05SensorID],[05Equation],[05RightDigit],[05SensorPos],[05Enable],[05HighLimit],[05StdDiv],[05LowLimit],[05Stats],[06SensorName],[06SensorID],[06Equation],[06RightDigit],[06SensorPos],[06Enable],[06HighLimit],[06StdDiv],[06LowLimit],[06Stats],[07SensorName],[07SensorID],[07Equation],[07RightDigit],[07SensorPos],[07Enable],[07HighLimit],[07StdDiv],[07LowLimit],[07Stats],[08SensorName],[08SensorID],[08Equation],[08RightDigit],[08SensorPos],[08Enable],[08HighLimit],[08StdDiv],[08LowLimit],[08Stats],[09SensorName],[09SensorID],[09Equation],[09RightDigit],[09SensorPos],[09Enable],[09HighLimit],[09StdDiv],[09LowLimit],[09Stats],[10SensorName],[10SensorID],[10Equation],[10RightDigit],[10SensorPos],[10Enable],[10HighLimit],[10StdDiv],[10LowLimit],[10Stats],[11SensorName],[11SensorID],[11Equation],[11RightDigit],[11SensorPos],[11Enable],[11HighLimit],[11StdDiv],[11LowLimit],[11Stats],[12SensorName],[12SensorID],[12Equation],[12RightDigit],[12SensorPos],[12Enable],[12HighLimit],[12StdDiv],[12LowLimit],[12Stats],[13SensorName],[13SensorID],[13Equation],[13RightDigit],[13SensorPos],[13Enable],[13HighLimit],[13StdDiv],[13LowLimit],[13Stats] from a11 where DatabaseTable='"+name+"'",con);
            cmd1.ExecuteScalar();
            SqlCommand cmd2 = new SqlCommand("update a11 set DatabaseTable='"+textBox5.Text+"', StationName='"+textBox4.Text+"',ProjectName='"+textBox11.Text+"',SatID='"+textBox9.Text+"',Latitude='"+textBox17.Text+"',Longitude='"+textBox16.Text+"',Altitude='"+textBox15.Text+"' where [sr no]=(select count(*) from a11);", con);
            cmd2.ExecuteNonQuery();
            con.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            String parameter = listBox1.Text.ToString();
            String ab;
            int i = 23;
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from a11 where DatabaseTable='" + name + "';", con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                while (true)
                {
                    
                    if (rd[i].Equals(null))
                    {
                        i++;
                        continue;
                    }
                    else
                    {
                        ab = rd[i].ToString();
                        i=i+1;
                        if (ab.Equals(parameter))
                            break;
                    }
                }
                textBox3.Text = parameter;
                textBox30.Text = rd[i].ToString();
                textBox29.Text = rd[i + 1].ToString();
                textBox36.Text = "0";
                textBox32.Text = rd[i + 2].ToString();
                textBox34.Text = rd[i + 5].ToString();
                textBox35.Text = rd[i + 6].ToString();
                textBox26.Text = rd[i + 7].ToString();
                checkBox3.Checked = true;
            }
            con.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        

        

        

        //private void button1_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void button14_Click_1(object sender, EventArgs e)
        //{

        //}
    }
}
