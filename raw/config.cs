using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace raw
{
    public partial class config : Form
    {
        public config()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void config_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form1.TimeInSeconds.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.TimeInSeconds = int.Parse(textBox1.Text);
            textBox1.ReadOnly = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
