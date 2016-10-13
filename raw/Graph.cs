using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;


namespace raw
{
    public partial class Graph : Form
    {
        double[] y = new double[100];
        double[] y1 = new double[100];
        String[] s = new String[100];
        //Project.report a = new Project.report();
        
        public Graph()
        {
            InitializeComponent();
        }
        
        int func, nonfunc;
        public static GraphPane myPane = null;
        private void Graph_Load(object sender, EventArgs e)
        {
            
            //func = Project.report.func;
            //nonfunc = Project.report.nonfunc;
           
           // MessageBox.Show("" + func + " " + nonfunc);
            initGraph();
            CreateGraph(func,nonfunc,zedGraphControl1);
        }

        public void initGraph()
        {
            try
            {

                for (int i = 0; i < Project.report.fs.Length; i++)
                {
                    y[i] = Project.report.fs[i].count;

                    y1[i] = Project.report.fs[i].total - Project.report.fs[i].count;
                    //MessageBox.Show(" " + y[i] + " " + y1[i]);
                    s[i] = Project.report.fs[i].Statename;
                }

            }
            catch (Exception E)
            { } //MessageBox.Show("" + E); }
        }
        

        public void CreateGraph(int func, int nonfunc, ZedGraphControl zgc)
        {
            
             myPane = zgc.GraphPane;
           
            //myPane.IsFontsScaled = true;
           
            
            // Set the title and axis label
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 200;
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 30;
            myPane.Title.Text = "Funcional and Non Functional Stations";
            myPane.YAxis.Title.Text = "No. of Stations";
            myPane.XAxis.Title.Text = "States";
           

           
           // SizeF f = new SizeF(2000, 2000);
            //CurveItem mcurve = myPane.AddBar("C",null,s,Color.Brown);
            CurveItem myCurve = myPane.AddBar("Functional ", null, y, Color.Blue);
            
            CurveItem myCurve1 = myPane.AddBar("Non Functional", null, y1, Color.Red);
            myPane.XAxis.MajorTic.IsBetweenLabels = true;
            //myPane.XAxis.Type = AxisType.Ordinal;
           // TextObj text = new TextObj("C", x, y + 0.1, CoordType.AxisXYScale, AlignH.Center, AlignV.Center);

            //myPane.XAxis.MajorTic.IsBetweenLabels = true;
            myPane.XAxis.Scale.IsPreventLabelOverlap = true;
            myPane.XAxis.Type = AxisType.Text;
            // Set the XAxis labels
            myPane.XAxis.Scale.TextLabels = s;

            myPane.XAxis.Scale.LabelGap = 0.1F;
            myPane.XAxis.MinSpace = 100;
            myPane.YAxis.Scale.LabelGap = 2;
            zgc.PerformAutoScale();
            // Indicate that the bars are overlay type, which are drawn on top of eachother

            //myPane.BarSettings.Type = BarType.Overla
            //y;

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0F);
            //zgc.Scale(f);
            // Calculate the Axis Scale Ranges
            zgc.AxisChange();
   
            // Add one step to the max scale value to leave room for the labels
            myPane.YAxis.Scale.Max += myPane.YAxis.Scale.MajorStep;
   

   
        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {
            
        }

        private void Savegraph_Click(object sender, EventArgs e)
        {
            
            Bitmap b =myPane.GetImage();
            b.Save("D:\\reports\\graph.jpeg");
        }
    }
}
