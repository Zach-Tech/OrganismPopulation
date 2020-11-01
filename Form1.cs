using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Zach Childers, CPT-185 / Spartanburg Community College

namespace Zachary_Childers_CPT_185_Lab_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            
        }
        private const int cGrip = 16;
        private const int cCaption = 32;

        protected override void WndProc(ref Message m)
        {
            if(m.Msg==0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption) { m.Result = (IntPtr)2;return;
                }
                if (pos.X>=this.ClientSize.Width-cGrip && pos.Y>=this.ClientSize.Height-cGrip)
                {
                    m.Result = (IntPtr)17;return;
                }
            }
            base.WndProc(ref m);
        }

        private void calc_Click(object sender, EventArgs e)
        {
          

                double numOrg, dlyInc; //1st is # of organisms, 2nd is daily increase
                int amtTime; // # of months
                int count = 1; // counter

                if (double.TryParse(orgStrt.Text, out numOrg)
                    && double.TryParse(dlyIncr.Text, out dlyInc)
                    && int.TryParse(dayMult.Text, out amtTime))
                {
                    orgResult.Items.Add("_________________________________________________________________________________________");
                    dlyInc /= 100;
                    while (count <= amtTime)
                    {
                        orgResult.Items.Add(count + "\t\t\t\t\t         " + numOrg);
                        count = count + 1;
                        numOrg += numOrg * dlyInc;
                    }
                }
                else { MessageBox.Show("Hey plz try again my dude"); }
        }

        private void clr_Click(object sender, EventArgs e)
        {

            orgStrt.Clear();
            dlyIncr.Clear();
            dayMult.Clear();
            orgResult.Items.Clear();
            orgStrt.Focus();
          
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
