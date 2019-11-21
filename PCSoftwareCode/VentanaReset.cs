using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramaSiprosaNeurociencia
{
    public partial class VentanaReset : Form
    {
        public VentanaReset()
        {
            InitializeComponent();
            this.loadTimer.Start();
        }

        private void loadTimer_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(1);

            if (progressBar1.Value == 100)
            {
                this.loadTimer.Stop();
                //Application.DoEvents();
                //Thread.Sleep(500);
                //this.Close();
            }
            //else
            //{
               // Form1.ArduinoPort.Write(((char)57).ToString());
           // }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
