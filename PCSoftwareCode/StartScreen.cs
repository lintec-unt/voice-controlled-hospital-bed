using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramaSiprosaNeurociencia
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void StarterTimer_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(1);
            if (progressBar1.Value == 30)
            {
                startLabel.Text = "Inicializando herramientas";
            }
            if (progressBar1.Value == 60)
            {
                startLabel.Text = "Leyendo preferencias";
            }
            if (progressBar1.Value == 90)
            {
                startLabel.Text = "Vinculando hardware";
            }
            if (progressBar1.Value == 6000)
            {
                this.StarterTimer.Stop();
            }
        }
    }
}
