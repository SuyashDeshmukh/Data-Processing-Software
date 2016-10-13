using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.Sql;
using Project;

namespace raw
{
    public partial class Form1 : Form
    {

        public static Button b1;
        public static int TimeInSeconds=20;
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
                /* if (login.loggedIn == 1)
                button1.Visible = true;
            else*/
                button1.Visible = false;
            
            Thread t = new Thread(decode);
            t.IsBackground = true;
            t.Start();

           // new Thread(decode).Start();           
        }

       
        private void decode()
        {
            String inpath = "C:\\Users\\lenovo\\Desktop\\TDMA\\TDMA RAW DECEMBER 2012\\20121208.amp";
            String outpath = "Year/2014";
            String line; //line1=null,statid=null;// str = null;
            Decoder d = new Decoder();
            DecoderARG darg = null;
            DecoderAWS daws = null;
            StreamReader reader = null; 
            reader=new StreamReader(inpath);

            int filename=int.Parse(Path.GetFileNameWithoutExtension(inpath));
            
            String dir = Path.GetDirectoryName(inpath);
            dir.Reverse();
            dir.TrimStart('\\');
            dir.Reverse();
            String inpath1 = dir; 
            //MessageBox.Show(inpath1);
            //MessageBox.Show(DateTime.Now.ToString("yyyyMMdd"));
            this.Invoke((MethodInvoker)delegate
            {
                textBox2.Text = inpath;
                textBox3.Text = outpath;
            });
            //SqlConnection con = new SqlConnection("Data Source=LENOVO-PC;Initial Catalog=Project;Integrated Security=True");
            int i = 0,count=0;
            //con.Open();
            DAO dao = new DAO();
            
            while (true)
            {
                
                if (count == 50)
                {
                    Thread.Sleep(TimeInSeconds*1000);
                    count = 0;
                }
                count++;

                line = reader.ReadLine();
                if (line == null)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show("File" + filename + " decoded succesfully");  
                    });
                    
                    filename++;
                    inpath1 = inpath1 +"\\"+ filename+".amp";
                    inpath1.Replace("\\", "\\\\");
                    reader = new StreamReader(inpath1);
                    this.Invoke((MethodInvoker)delegate
                    {
                        textBox1.Clear();
                    });
                    continue;

                }
                
                String id=d.separateParam(line);
                
                    dao.getConnection();
                    String type = dao.getStationType(id);
                    String name = dao.getStationName(id);
                    String state = dao.getStateName(id);
                    dao.insertStation(d, name, state);

                    if (type.Equals("IMD_ARG"))
                    {
                        darg = new DecoderARG();
                        darg.decodeARG(d, name);
                        // dao.insertStation(d, name);

                    }
                    else if (type.Equals("IMD_AWS"))
                    {
                        daws = new DecoderAWS();
                        daws.decodeAWS(d, name);
                        
                    }
                   
                    dao.closeConnection();
                    i++;
                    try
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            textBox1.Text = textBox1.Text + DateTime.Now + " Raw data for station ID " + id + " for station display name " + name + " from " + state + " and for record time " + d.Date + "\r\n";
                        });
                    }
                    catch (Exception e)
                    { }
                
            }
            //con.Close();
           // MessageBox.Show("Decoding Complete");
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Form2 f2 = new Form2();
            //f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Viewer vie = new Viewer();
            vie.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            report r = new report();
            r.Show();
            /*DAO d = new DAO();
            String abc=d.test();
            MessageBox.Show(abc);
        */}

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (login.loggedIn == 0)
            {
                login log = new login();
                log.Show();
            }
            button1.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (login.loggedIn == 1)
            {
                config c1 = new config();
                c1.Show();
            }
            else
            {
                login l1 = new login();
                l1.Show();
                
            }     
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            addst st = new addst();
            st.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            login.loggedIn = 0;
            button1.Visible = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            
            Application.Exit();
        }
               
    }
}
