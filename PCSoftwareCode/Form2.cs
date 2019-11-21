using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;


namespace ProgramaSiprosaNeurociencia
{
    public partial class Form2 : Form
    {
        private string x;
        private string y;

        public string Xpos
        {
            set
            {
                x = value;
            }
            get
            {
                return x;
            }
        }

        public string Ypos
        {
            set
            {
                y = value;
            }
            get
            {
                return y;
            }
        }


        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Obtenemos las dimensiones de la pantalla principal (area de trabajo)
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            
            //int ejeX = workingRectangle.Width - (workingRectangle.Width / 3);
            x = 0.ToString();
            y = 0.ToString();

            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Obtenemos las dimensiones de la pantalla principal (area de trabajo)
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;

            x = (workingRectangle.Width - (2 * (workingRectangle.Width / 3))).ToString();
            y = 0.ToString();

            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Obtenemos las dimensiones de la pantalla principal (area de trabajo)
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;

            x = (workingRectangle.Width - (workingRectangle.Width / 3)-150).ToString();
            y = 0.ToString();

            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //Obtenemos las dimensiones de la pantalla principal (area de trabajo)
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;

            x = 0.ToString();
            y = (workingRectangle.Height - (2* (workingRectangle.Height/3))).ToString();

            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //Obtenemos las dimensiones de la pantalla principal (area de trabajo)
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;

            x = (workingRectangle.Width - (2*(workingRectangle.Width / 3))).ToString();
            y = (workingRectangle.Height - (2 * (workingRectangle.Height / 3))).ToString();

            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //Obtenemos las dimensiones de la pantalla principal (area de trabajo)
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;

            x = (workingRectangle.Width - (workingRectangle.Width / 3)-150).ToString();
            y = (workingRectangle.Height - (2 * (workingRectangle.Height / 3))).ToString();

            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //Obtenemos las dimensiones de la pantalla principal (area de trabajo)
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;

            x = 0.ToString();
            y = (workingRectangle.Height - (workingRectangle.Height / 3)-100).ToString();

            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //Obtenemos las dimensiones de la pantalla principal (area de trabajo)
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;

            x = (workingRectangle.Width - (2 * (workingRectangle.Width / 3))).ToString();
            y = (workingRectangle.Height - (workingRectangle.Height / 3)-100).ToString();

            this.Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            //Obtenemos las dimensiones de la pantalla principal (area de trabajo)
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;

            x = (workingRectangle.Width - (workingRectangle.Width / 3)-150).ToString();
            y = (workingRectangle.Height - (workingRectangle.Height / 3)-100).ToString();

            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
