using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace raw
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DAO dao = new DAO();
            String table=Convert.ToString(comboBox1.SelectedItem);
            String query = "select * from " + table+";";
            //ds = dao.viewer();
            dataGridView1.DataSource = ds.Tables["ss"];            
        }
    }
}
