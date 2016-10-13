using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace raw
{
    public partial class Viewer : Form
    {
        public Viewer()
        {
            InitializeComponent();
        }

        private void GetStations_Click(object sender, EventArgs e)
        {
            DAO dao = new DAO();
            //int index = ParameterList.SelectedIndex;
            String name = ParameterList.Text.ToString();
           // MessageBox.Show(name);
            //listBox2.Text = "" + listBox1.SelectedItem;
            DataSet ds = new DataSet();
            ds=dao.getStations(name,(String)prototype.SelectedItem);
            StationList.DataSource = ds.Tables["0"];
            StationList.DisplayMember = "DatabaseTable";
            /*comboBox3.DataSource = ds.Tables["0"];
            comboBox3.DisplayMember = "DatabaseTable";*/
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void GetParameters_Click(object sender, EventArgs e)
        {
            DAO dao = new DAO();
            String name = (String)SelectParameter.SelectedItem;
            //MessageBox.Show(name);
            //listBox2.Text = "" + listBox1.SelectedItem;
            DataSet ds = new DataSet();
            ds = dao.getStates(name);
            ParameterList.DataSource = ds.Tables["1"];
            ParameterList.DisplayMember = "StateName";
        }

        private void DisplayData_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DAO dao = new DAO();
            String table = StationList.Text.ToString();
            MessageBox.Show(table);
            String fromDate = Convert.ToString(FromDate.Value);
            String toDate = Convert.ToString(ToDate.Value);
            String para="DateAndTime,ReportingTime1,ReportingTime2,ReportingTime3,GoodBurst,BadBurst,TotalBurst,Status,GPSstatus,WMOmsg";
            CheckedListBox.CheckedItemCollection obj= checkedListBox1.CheckedItems;
            foreach (Object ab in obj)
            {
                para = String.Concat(para, ",", ab.ToString());
            }
            //para=para.Remove(0, 1);
            //MessageBox.Show(para);
            //String query = "select "+para+" from [" + table + "];";
            if (fromDate.Equals(DateTime.Now) && toDate.Equals(DateTime.Now))
            {
                fromDate = toDate = null;
            }

           // MessageBox.Show(fromDate +" "+ toDate+" "+DateTime.Now);
            ds = dao.viewer(para,table,fromDate,toDate);
            dataGridView1.DataSource = ds.Tables["ss"];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SelectParameter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClearList_Click(object sender, EventArgs e)
        {
            StationList.DataSource = null;
            StationList.Items.Clear();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GetData_Click(object sender, EventArgs e)
        {
            

                    
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add(Missing.Value);

            Excel.Worksheet ws = null;

            // changing the name of active sheet
            //ws.Name = "Functional Stations";

            ws = wb.Sheets["Sheet1"];
            ws = wb.ActiveSheet;

            ws.Name = StationList.Text.ToString() ;

            ws.Rows.HorizontalAlignment = HorizontalAlignment.Center;
            // storing header part in Excel
            for (int i = 1; i <dataGridView1.Columns.Count + 1; i++)
            {
                ws.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }



            // storing Each row and column value to excel sheet
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    ws.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }



            String outfile = "D:\\reports\\"+ws.Name+".xlsx";
            wb.SaveAs(outfile, Type.Missing, Type.Missing, Type.Missing,
                            Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                            Type.Missing);
            app.Quit();

            
        }
    }
}
