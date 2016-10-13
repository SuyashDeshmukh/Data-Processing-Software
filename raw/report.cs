using raw;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel=Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Project
{
    public partial class report : Form
    {
        public struct functionalStations
        {
            public String Statename;
            public int count;
            public int total;
        };
        public static functionalStations[] fs = new  functionalStations[50];
            //public static report[] r = null;//new report[100];
        DataSet functional = new DataSet();
        public static int func;
        public static  int nonfunc;
        DataTable dt;
        public report()
        {
            InitializeComponent();
        }

        public void label1_Click(object sender, EventArgs e)
        {

        }

        public void label3_Click(object sender, EventArgs e)
        {

        }

        public void label4_Click(object sender, EventArgs e)
        {

        }

        public void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        public void label5_Click(object sender, EventArgs e)
        {

        }

        public void GenerateReport_Click(object sender, EventArgs e)
        {
            
            DAO dao = new DAO();
            try
            {
                dataTableInit();
                String fd = FromDate.Value.ToString();
                String td = ToDate.Value.ToString();
                functional = dao.getfunctional(fd, td);
               
                reportView.DataSource = functional.Tables["1"];
               
                //DataSet nonfunctional = new DataSet() ;
                functional = dao.getnonfunctional(fd, td);
                reportView1.DataSource = functional.Tables["2"];

                func = reportView.RowCount;

                nonfunc = reportView1.RowCount;
                
                
                for (int i = 0; i < func; i++)
                {


                    DataGridViewCell dg = reportView["DatabaseTable", i];
                    String name = dg.Value.ToString() ;
                    //MessageBox.Show("in the loop"+name);
                    String sname = dao.getStateName1(name);
                    //MessageBox.Show("looop " + sname);
                    calcFunctional(sname);
                 }

               }
               catch (Exception E)
                { }
              
        }

        public void calcFunctional(String sname)
        {
            for (int i = 0; i < fs.Length; i++)
            {
                if (fs[i].Statename.Equals(sname))
                {
                    fs[i].count++;
                    break;
                }
            }

            /*for (int i = 0; i < fs.Length; i++)
            {
                MessageBox.Show(fs[i].Statename + " " + fs[i].count + " " + fs[i].total);
            }?*/
        }

        public void dataTableInit()
        {
            DAO d = new DAO();
            dt = new DataTable();
            dt.Columns.Add("StateName", typeof(String));
            dt.Columns.Add("Functional Stations", typeof(int));
            
            dt=d.getAllStates();
            int i=0,flag=0;
            foreach(DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    if (flag == 0)
                    {
                        fs[i].Statename = dr[dc].ToString();
                        //MessageBox.Show(fs[i].Statename);
                        flag = 1;
                    }
                    else
                    {
                        fs[i].total = Convert.ToInt16(dr[dc].ToString());
                        flag = 0;
                       // MessageBox.Show(fs[i].Statename+" "+fs[i].count+" "+fs[i].total);
                        i++;

                    }

                }
            
            }
 
        }

        private void reportView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ClearReport_Click(object sender, EventArgs e)
        {
            reportView.DataSource = null;
            reportView1.DataSource=null;
        }

        public void ExportToExcel_Click(object sender, EventArgs e)
        {
            
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add(Missing.Value);
            Excel.Worksheet ws = (Excel.Worksheet)wb.Sheets[1];
            // changing the name of active sheet
            ws.Name = "Functional Stations";

            ws.Rows.HorizontalAlignment = HorizontalAlignment.Center;
            // storing header part in Excel
            for (int i = 1; i < reportView.Columns.Count + 1; i++)
            {
                ws.Cells[1, i] = reportView.Columns[i - 1].HeaderText;
            }



            // storing Each row and column value to excel sheet
            for (int i = 0; i < reportView.Rows.Count - 1; i++)
            {
                for (int j = 0; j < reportView.Columns.Count; j++)
                {
                    ws.Cells[i + 2, j + 1] = reportView.Rows[i].Cells[j].Value.ToString();
                }
            }
            


            Excel.Worksheet ws1 = (Excel.Worksheet)wb.Sheets[2];
            // changing the name of active sheet
            ws1.Name = "Non Functional Stations";

            ws1.Rows.HorizontalAlignment = HorizontalAlignment.Center;
            // storing header part in Excel
            for (int i = 1; i < reportView1.Columns.Count + 1; i++)
            {
                ws1.Cells[1, i] = reportView1.Columns[i - 1].HeaderText;
            }



            // storing Each row and column value to excel sheet
            for (int i = 0; i < reportView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < reportView1.Columns.Count; j++)
                {
                    ws1.Cells[i + 2, j + 1] = reportView1.Rows[i].Cells[j].Value.ToString();
                }
            }

            String outfile = "D:\\report.xlsx";
            wb.SaveAs(outfile, Type.Missing, Type.Missing, Type.Missing,
                            Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                            Type.Missing);
            app.Quit();

        }

        private void GenerateGraphs_Click(object sender, EventArgs e)
        {
            //func = reportView.Rows.Count;
            //nonfunc = reportView1.Rows.Count;
           // MessageBox.Show(""+func+" "+nonfunc);

            Graph g = new Graph();
            
            g.Show();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void report_Load(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
